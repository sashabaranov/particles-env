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

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новыйЭкспериментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExperimentAdd c = new ExperimentAdd(GenerateNewExpirementList()); //объект диалога

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExperimentControl p = new ExperimentControl();
                p.Expirement = c.ExpirementObject;
                
                p.Size = Tabs.Size;
                p.Left = Tabs.Left;
                p.Top = Tabs.Top - 25;

                p.Expirement.Graphics.SetDrawingBorder(p.Left, p.Top, p.Size);

                //Обработчик нужд эксперимента
                switch (p.Expirement.Graphics.Needs)
                {
                    case ExpirementNeeds.None: break;
                    case ExpirementNeeds.Normal: break; //нормальный обработчик
                    case ExpirementNeeds.ZedGraph: 
                        //добавить контролл
                        ZedGraph.ZedGraphControl zgc = new ZedGraph.ZedGraphControl();
                        p.Controls.Add(zgc);

                        c.ExpirementObject.Graphics.CreateControl(zgc); //добавить контрол Zedgraph'а
                        break; 

                    case ExpirementNeeds.XNA: break;//включить 3д-режим
                }


                p.Anchor = AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Left;
                
                Tabs.TabPages.Add("exp" + ExpirementCount, "Эксперимент " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                Tabs.TabPages[ExpirementCount].Focus();
             
                ExpirementCount++;

            }

        }

        private void addExpirementType_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!Dlls.Contains(openFileDialog1.FileName)) // проверка на повторное добавление
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
                    DirectoryInfo ModulesDir = new DirectoryInfo("modules"); // открываем папку с модулями
                    FileInfo[] Modules = ModulesDir.GetFiles("*.dll");  // берём все *.dll файлы

                    foreach (FileInfo Module in Modules)
                    {
                        Dlls.Add(Module.FullName); // проверка неуместна, метод вызывается при загрузке программы.
                    }
                }
                else
                {
                    Directory.CreateDirectory("modules");
                    throw new Exception("Стандартная директория модулей не найдена, создана новая директория modules.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Что-то пошло не так:\n" + e.Message, "Ошибка");
            }

        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ExpirementStats c = new ExpirementStats(GenerateNewExpirementList()); //объект диалога
            ExpStats c = new ExpStats(GenerateNewExpirementList(), ref this.Tabs);
            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExperimentControl p = new ExperimentControl();
                p.Expirement = c.ExpirementObject;


                Tabs.TabPages.Add("exp" + ExpirementCount, "Эксперимент " + ExpirementCount);
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
            else MessageBox.Show("Извините, но у вас же нет открытых экспериментов!", "Ошибка");
        }

    }
}