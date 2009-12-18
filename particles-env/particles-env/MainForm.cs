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
        int ExperimentCount;
        static ExperimentList ExpList;
        List<string> Dlls;

        public MainForm()
        {
            InitializeComponent();
            Dlls = new List<string>();
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExperimentAdd c = new ExperimentAdd(GenerateNewExperimentList()); //������ �������

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                AddNewTabWithExperiment(c.ExperimentObject);
            }

        }

        public void AddNewTabWithExperiment(Experiment c)
        {
            ExperimentControl p = new ExperimentControl();
            p.Experiment = c;
            p.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            p.Size = Tabs.Size;
            p.Left = Tabs.Left;
            p.Top = Tabs.Top - 25;

            Size _Size = p.Size;
            _Size.Width -= 200;

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
                        myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0F);
                        break;
                case ExperimentNeeds.OpenGL:
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

            p.LoadParameters(p.Experiment.Graphics.ParameterListTemplate);
            p.Experiment.pList = p.Experiment.Graphics.ParameterListTemplate;

            p.Experiment.Graphics.SetParameters(p.Experiment.Graphics.ParameterListTemplate);
            p.Anchor = AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Left;

            Tabs.TabPages.Add("exp" + ExperimentCount, "����������� " + ExperimentCount);
            Tabs.TabPages[ExperimentCount].Controls.Add(p);
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
            ExpStats c = new ExpStats(GenerateNewExperimentList(), ref this.Tabs);
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
                
                c.Left = Page.Left - 5;
                c.Top  = Page.Top - 25;
                c.Size = Page.Size; 

                c.Experiment.Graphics.SetDrawingBorder(c.Left, c.Top, c.Size);
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


    }
}