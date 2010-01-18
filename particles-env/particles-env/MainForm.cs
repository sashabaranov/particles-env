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
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace particles_env
{
    public partial class MainForm : Form
    {
        int ExperimentCount = 1;
        static ExperimentList ExpList;
        List<string> Dlls;

        public MainForm()
        {
            InitializeComponent();
            Dlls = new List<string>();
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExperimentAdd c = new ExperimentAdd(ExpList); //������ �������

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                AddNewTabWithExperiment(c.ExperimentObject);
            }

        }

        public void AddNewTabWithExperiment(Experiment c)
        {
            ExperimentControl p = new ExperimentControl();
            p.Name = "ExpCtrl";
            p.LoadExperiment(c);

            p.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            p.Size = Tabs.Size;
            p.Left = Tabs.Left;
            p.Top = Tabs.Top - 25;

            Size _Size = p.Size;
            _Size.Width -= 202;
            _Size.Height -= 26;
            //p.Size = _Size;
            p.Experiment.Graphics.SetDrawingBorder(p.Left, p.Top, _Size);

            //���������� ���� ������������
            switch (p.Experiment.Graphics.Needs)
            {
                case ExperimentNeeds.None: break;
                case ExperimentNeeds.Normal: break; //���������� ����������
                case ExperimentNeeds.ZedGraph:
                    //�������� ��������
                    ZedGraph.ZedGraphControl zgc = new ZedGraph.ZedGraphControl();
                    zgc.Size = _Size;
                    p.Controls.Add(zgc);
                    GraphPane zgcPane = zgc.GraphPane;
                    zgcPane.Chart.Fill = new Fill(Color.Red, Color.Blue, 45.0F);
                    p.Experiment.Graphics.CreateControl(zgc); //�������� ������� Zedgraph'�
                    break;

                case ExperimentNeeds.XNA: break;//�������� 3�-�����
                case ExperimentNeeds.Graph:
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
                        p.Experiment.Graphics.SetGraphInfo(myPane);
                        myPane.Legend.IsVisible = false;
                        myPane.Chart.Fill = new Fill(Color.Red, Color.Blue, 45.0F);
                        break;
                case ExperimentNeeds.OpenGL:
                        SimpleOpenGlControl tao_ctrl = new SimpleOpenGlControl();
                        tao_ctrl.Size = _Size;
                        tao_ctrl.Name = "TaoControl";
                        p.Controls.Add(tao_ctrl);
                        tao_ctrl.MouseDown += p.OGL_MouseDown;
                        tao_ctrl.MouseUp += p.OGL_MouseUp;
                        tao_ctrl.MouseMove += p.OGL_MouseMove;
                        tao_ctrl.MouseWheel += p.OGL_MouseWheel;
                        tao_ctrl.KeyDown += p.OGL_KeyDown;

                        tao_ctrl.InitializeContexts();
                        break;
            }

            p.LoadParameters(p.Experiment.Graphics.ParameterListTemplate);
            p.Experiment.pList = p.Experiment.Graphics.ParameterListTemplate;

            p.Experiment.Graphics.SetParameters(p.Experiment.Graphics.ParameterListTemplate);
            p.Anchor = AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Left;

            Tabs.TabPages.Add("exp" + ExperimentCount, "����������� " + ExperimentCount);
            Tabs.TabPages[ExperimentCount].Controls.Add(p);
            Tabs.SelectTab(ExperimentCount);
            Tabs.TabPages[ExperimentCount].Focus();

            ExperimentCount++;
        }

        private void addExperimentType_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!Dlls.Contains(openFileDialog1.FileName)) // �������� �� ��������� ����������
                {
                    Dlls.Add(openFileDialog1.FileName);

                    ExpList = GenerateNewExperimentList();
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            AddModulesFromDefaultFolder();
            ExpList = GenerateNewExperimentList();

            ExperimentAddControl c = (ExperimentAddControl)tabPage1.Controls["experimentAddControl1"];

            
            c.SetList(ExpList);
            c.UserSelected += new ExperimentAddControl.UserSelectedHandler(c_UserSelected);

            //little fixup on the go
            c.DoneButton.Text = "��������";
            c.DescriptionBox.BackColor = SystemColors.Window;
            
        }

        void c_UserSelected(object sender, Experiment ExperimentObject)
        {
            AddNewTabWithExperiment(ExperimentObject);
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
                        if (Module.Name != "MDK.dll" && Module.Name != "ZedGraph")
                            Dlls.Add(Module.FullName); // �������� ���������, ����� ���������� ��� �������� ���������.
                    }
                }
                else
                {
                    Directory.CreateDirectory("modules");
                    throw new Exception("����������� ���������� ������� �� �������, ������� ����� ���������� modules.");
                }
            }
            finally {  }
        }


        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private ExperimentList GenerateNewExperimentList()
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
            ExperimentList expsList = new ExperimentList();
            ExperimentInfo expinf = new ExperimentInfo();
            foreach (TabPage tab in Tabs.TabPages)
            {
                if (tab.Text == "��������� ��������") continue;
                expinf = new ExperimentInfo("", ((ExperimentControl)tab.Controls.Find("ExpCtrl", true)[0]).Experiment.Graphics);
                //expinf.GraphicsObj = ((ExperimentControl)tab.Controls.Find("ExpCtrl", true)[0]).Experiment.Graphics;
                bool k = false;
                foreach (ExperimentInfo e_i in expsList.eList)
                {
                    if (e_i.GraphicsObj == expinf.GraphicsObj) k = true; 
                }
                if (!k) expsList.eList.Add(expinf);
            }
            ExpStats c = new ExpStats(expsList, ref this.Tabs);

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExperimentControl p = new ExperimentControl();
                p.Experiment = c.ExperimentObject;


                Tabs.TabPages.Add("exp" + ExperimentCount, "����������� " + ExperimentCount);
                Tabs.TabPages[ExperimentCount].Controls.Add(p);
                Tabs.TabPages[ExperimentCount].Focus();

                ExperimentCount++;

            }
        }
        /*
        private void Tabs_Resize(object sender, EventArgs e)
        {
            foreach (TabPage Page in Tabs.TabPages)
            {
                Control c =  Page.Controls[0];
                
                c.Left = Page.Left - 5;
                c.Top  = Page.Top - 25;
                c.Size = Page.Size; 

                //c.Experiment.Graphics.SetDrawingBorder(c.Left, c.Top, c.Size);
            }
        }*/

        private void Tabs_Selected(object sender, TabControlEventArgs e)
        {
            Tabs.SelectedTab.Invalidate();
        }

        #region ���������� � �������� �������������
        private void SaveExperiment(object sender, EventArgs e)
        {
            if (Tabs.TabPages.Count > 0)
            {
                DialogResult d = SaveDialog.ShowDialog();
                if (d != DialogResult.Abort && d != DialogResult.Cancel)
                {
                    ExperimentControl p = (ExperimentControl)Tabs.TabPages[Tabs.SelectedIndex].Controls[0];
                    try
                    {
                        XmlSerializer xmlFormat = new XmlSerializer(p.Experiment.GetType(), new Type[] {p.Experiment.Graphics.GetType()} );
                        FileStream fStream = new FileStream(SaveDialog.FileName, FileMode.OpenOrCreate);

                        xmlFormat.Serialize(fStream, p.Experiment);
                   }
                    catch (Exception ex)
                    {
                        MessageBox.Show("���-�� ����� �� ���:\r\n" + ex.Message);
                    }

                    
                }
            }
            else MessageBox.Show("��������, �� � ��� �� ��� �������� �������������!", "������");
        }

        private void LoadExperiment(object sender, EventArgs e)
        {
            DialogResult d = openExperimentDialog.ShowDialog();
            
            if (d == DialogResult.OK)
            {
                try
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(Experiment), GenerateNewExperimentList().GetTypes());
                    Experiment obj = (Experiment)xmlFormat.Deserialize(new FileStream(openExperimentDialog.FileName, FileMode.Open));

                    AddNewTabWithExperiment(obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("���-�� ����� �� ���: " + ex.Message);
                }
            }

        }
        #endregion
    }
}