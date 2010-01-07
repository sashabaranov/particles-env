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

        private void новыйЭкспериментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExperimentAdd c = new ExperimentAdd(ExpList); //объект диалога

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                AddNewTabWithExperiment(c.ExperimentObject);
            }

        }

        public void AddNewTabWithExperiment(Experiment c)
        {
            ExperimentControl p = new ExperimentControl();
            p.LoadExperiment(c);

            p.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            p.Size = Tabs.Size;
            p.Left = Tabs.Left;
            p.Top = Tabs.Top - 25;

            Size _Size = p.Size;
            _Size.Width -= 200;

            p.Experiment.Graphics.SetDrawingBorder(p.Left, p.Top, _Size);

            //Обработчик нужд эксперимента
            switch (p.Experiment.Graphics.Needs)
            {
                case ExperimentNeeds.None: break;
                case ExperimentNeeds.Normal: break; //нормальный обработчик
                case ExperimentNeeds.ZedGraph:
                    //добавить контролл
                    ZedGraph.ZedGraphControl zgc = new ZedGraph.ZedGraphControl();
                    zgc.Size = _Size;
                    p.Controls.Add(zgc);

                    p.Experiment.Graphics.CreateControl(zgc); //добавить контрол Zedgraph'а
                    break;

                case ExperimentNeeds.XNA: break;//включить 3д-режим
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
                        tao_ctrl.Width = _Size.Width;
                        tao_ctrl.Height = _Size.Height - 30;
                        tao_ctrl.Name = "TaoControl";
                        p.Controls.Add(tao_ctrl);
                        tao_ctrl.MouseDown += p.OGL_MouseDown;
                        tao_ctrl.MouseUp += p.OGL_MouseUp;
                        tao_ctrl.MouseMove += p.OGL_MouseMove;

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

                        break;
            }

            p.LoadParameters(p.Experiment.Graphics.ParameterListTemplate);
            p.Experiment.pList = p.Experiment.Graphics.ParameterListTemplate;

            p.Experiment.Graphics.SetParameters(p.Experiment.Graphics.ParameterListTemplate);
            p.Anchor = AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Left;

            Tabs.TabPages.Add("exp" + ExperimentCount, "Эксперимент " + ExperimentCount);
            Tabs.TabPages[ExperimentCount].Controls.Add(p);
            Tabs.SelectTab(ExperimentCount);
            Tabs.TabPages[ExperimentCount].Focus();

            ExperimentCount++;
        }

        private void addExperimentType_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!Dlls.Contains(openFileDialog1.FileName)) // проверка на повторное добавление
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
            c.DoneButton.Text = "Добавить";
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
                    DirectoryInfo ModulesDir = new DirectoryInfo("modules"); // открываем папку с модулями
                    FileInfo[] Modules = ModulesDir.GetFiles("*.dll");  // берём все *.dll файлы

                    foreach (FileInfo Module in Modules)
                    {
                        if (Module.Name != "MDK.dll" && Module.Name != "ZedGraph")
                            Dlls.Add(Module.FullName); // проверка неуместна, метод вызывается при загрузке программы.
                    }
                }
                else
                {
                    Directory.CreateDirectory("modules");
                    throw new Exception("Стандартная директория модулей не найдена, создана новая директория modules.");
                }
            }
            finally {  }
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpStats c = new ExpStats(GenerateNewExperimentList(), ref this.Tabs);

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExperimentControl p = new ExperimentControl();
                p.Experiment = c.ExperimentObject;


                Tabs.TabPages.Add("exp" + ExperimentCount, "Эксперимент " + ExperimentCount);
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

        #region Сохранение и Загрузка экспериментов
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
                        MessageBox.Show("Что-то пошло не так:\r\n" + ex.Message);
                    }

                    
                }
            }
            else MessageBox.Show("Извините, но у вас же нет открытых экспериментов!", "Ошибка");
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
                    MessageBox.Show("Что-то пошло не так: " + ex.Message);
                }
            }

        }
        #endregion
    }
}