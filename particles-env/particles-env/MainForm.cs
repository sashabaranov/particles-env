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
                AddNewTabWithExpirement(c.ExpirementObject);
            }

        }

        public void AddNewTabWithExpirement(Experiment c)
        {
            ExperimentControl p = new ExperimentControl();
            p.Expirement = c;

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

                    p.Expirement.Graphics.CreateControl(zgc); //�������� ������� Zedgraph'�
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
                        p.Expirement.Graphics.SetGraphInfo(myPane);
                        myPane.Legend.IsVisible = false;
                        myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0F);
                        break;
                case ExpirementNeeds.OpenGL:
                        SimpleOpenGlControl tao_ctrl = new SimpleOpenGlControl();
                        tao_ctrl.Size = _Size;
                        p.Controls.Add(tao_ctrl);
                        tao_ctrl.InitializeContexts();
                        
                        Glut.glutInit();
                        Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
                    
                        Gl.glClearColor(0, 0, 0, 1);
                        Gl.glViewport(0, 0, tao_ctrl.Width, tao_ctrl.Height);

                        Gl.glMatrixMode(Gl.GL_PROJECTION);
                        Gl.glLoadIdentity();
                        Glu.gluPerspective(45, (float)tao_ctrl.Width / (float)tao_ctrl.Height, 0.1, 200);
                        Gl.glMatrixMode(Gl.GL_MODELVIEW);
                        Gl.glLoadIdentity();

                        Gl.glEnable(Gl.GL_DEPTH_TEST);
                        Gl.glEnable(Gl.GL_LIGHTING);
                        Gl.glEnable(Gl.GL_LIGHT0);
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
                        XmlSerializer xmlFormat = new XmlSerializer(p.Expirement.GetType(), new Type[] {p.Expirement.Graphics.GetType()} );
                        FileStream fStream = new FileStream(SaveDialog.FileName, FileMode.OpenOrCreate);

                        xmlFormat.Serialize(fStream, p.Expirement);
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
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(Experiment), GenerateNewExpirementList().GetTypes());
                    Experiment obj = (Experiment)xmlFormat.Deserialize(new FileStream(openExperimentDialog.FileName, FileMode.Open));

                    AddNewTabWithExpirement(obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("���-�� ����� �� ���: " + ex.Message);
                }
            }

        }


    }
}