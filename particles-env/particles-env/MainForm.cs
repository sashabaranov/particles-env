using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using MDK;
using ZedGraph;

namespace particles_env
{
    public partial class MainForm : Form
    {
        int ExpirementCount;
        static ExperimentList ExpList;
        List<string> Dlls;

        public MainForm()
        {
            InitializeComponent();
            Dlls = new List<string>();
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExperimentAdd c = new ExperimentAdd(GenerateNewExpirementList()); //������ �������

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExperimentControl p = new ExperimentControl();
                p.Expirement = c.ExpirementObject;
                
                p.Size = Tabs.Size;
                p.Left = Tabs.Left;
                p.Top = Tabs.Top - 25;
                
                Size _Size = p.Size;
                _Size.Width -= 200;
                
                p.Expirement.Graphics.SetDrawingBorder(p.Left, p.Top, _Size);

                //���������� ���� ������������
                switch (p.Expirement.Graphics.Needs)
                {
                    case ExpirementNeeds.None: break;
                    case ExpirementNeeds.Normal: break; //���������� ����������
                    case ExpirementNeeds.ZedGraph: 
                        //�������� ��������
                        ZedGraph.ZedGraphControl zgc = new ZedGraph.ZedGraphControl();
                        zgc.Size = _Size;
                        p.Controls.Add(zgc);

                        c.ExpirementObject.Graphics.CreateControl(zgc); //�������� ������� Zedgraph'�
                        break; 

                    case ExpirementNeeds.XNA: break;//�������� 3�-�����
                    case ExpirementNeeds.Graph:
                        ZedGraphControl graph = new ZedGraphControl();
                        graph.Size = _Size;
                        p.Controls.Add(graph);
                        
                        GraphPane myPane;
                        /*graph.Top = 0; 
                        graph.Left = 0;
                        graph.Height = this.Height;
                        graph.Width = this.Width;
                        */
                        myPane = graph.GraphPane;
                        c.ExpirementObject.Graphics.SetGraphInfo(myPane);
                        myPane.Legend.IsVisible = false;
                        myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0F);
                        break;
                }

                p.LoadParameters(p.Expirement.Graphics.ParameterListTemplate);
                p.Expirement.pList = p.Expirement.Graphics.ParameterListTemplate;

                p.Expirement.Graphics.SetParameters(p.Expirement.Graphics.ParameterListTemplate);
                p.Anchor = AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Left;
                
                Tabs.TabPages.Add("exp" + ExpirementCount, "����������� " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                Tabs.TabPages[ExpirementCount].Focus();
             
                ExpirementCount++;
            }

        }

        private void addExpirementType_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!Dlls.Contains(openFileDialog1.FileName)) // �������� �� ��������� ����������
                {
                    Dlls.Add(openFileDialog1.FileName);
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            AddModulesFromDefaultFolder();
            this.DoubleBuffered = true;
        }

        private void AddModulesFromDefaultFolder()
        {
            try
            {
                if (Directory.Exists("modules"))
                {
                    DirectoryInfo ModulesDir = new DirectoryInfo("modules"); // ��������� ����� � ��������
                    FileInfo[] Modules = ModulesDir.GetFiles("*.dll");  // ���� ��� *.dll �����

                    foreach (FileInfo Module in Modules)
                    {
                        if(Module.Name!="MDK.dll" && Module.Name!="ZedGraph")
                            Dlls.Add(Module.FullName); // �������� ���������, ����� ���������� ��� �������� ���������.
                    }
                }
                else
                {
                    Directory.CreateDirectory("modules");
                    throw new Exception("����������� ���������� ������� �� �������, ������� ����� ���������� modules.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("���-�� ����� �� ���:\n" + e.Message, "������");
            }

        }


        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private ExperimentList GenerateNewExpirementList()
        {
            ExperimentList Lst = new ExperimentList();

            
            foreach (string p in Dlls)
            {
                Lst.LoadDll(p);
            }
            
            return Lst;
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ExpirementStats c = new ExpirementStats(GenerateNewExpirementList()); //������ �������
            ExpStats c = new ExpStats(GenerateNewExpirementList(), ref this.Tabs);
            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExperimentControl p = new ExperimentControl();
                p.Expirement = c.ExpirementObject;


                Tabs.TabPages.Add("exp" + ExpirementCount, "����������� " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                Tabs.TabPages[ExpirementCount].Focus();

                ExpirementCount++;

            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tab = new TabControl();
            for (int i = 0; i < tab.TabPages.Count; i++)
            {
                MessageBox.Show(tab.TabPages[i].Name);
            }

        }

        private void Tabs_Resize(object sender, EventArgs e)
        {
            foreach (TabPage Page in Tabs.TabPages)
            {
                ExperimentControl c = (ExperimentControl) Page.Controls[0];
                
                c.Left = Page.Left;
                c.Top  = Page.Top;
                c.Size = Page.Size; 

                c.Expirement.Graphics.SetDrawingBorder(c.Left, c.Top, c.Size);
            }
        }

        private void Tabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
        }

        private void Tabs_Selected(object sender, TabControlEventArgs e)
        {
            Tabs.SelectedTab.Invalidate();
        }

        private void SaveExpirement(object sender, EventArgs e)
        {
            if (Tabs.TabPages.Count > 0)
            {
                if (SaveDialog.ShowDialog() != DialogResult.Abort && SaveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    ExperimentControl p = (ExperimentControl) Tabs.TabPages[Tabs.SelectedIndex].Controls[0];
                    XmlSerializer xmlFormat = new XmlSerializer(p.Expirement.GetType());

                    MessageBox.Show(SaveDialog.FileName);
                    FileStream fStream = new FileStream(SaveDialog.FileName, FileMode.OpenOrCreate);

                    xmlFormat.Serialize(fStream, p.Expirement);
                }
            }
            else MessageBox.Show("��������, �� � ��� �� ��� �������� �������������!", "������");
        }

    }
}