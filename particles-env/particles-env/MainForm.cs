using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MDK;

namespace particles_env
{
    public partial class MainForm : Form
    {
        int ExpirementCount;
        static ExpirementList ExpList;
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
            ExpirementAdd c = new ExpirementAdd(GenerateNewExpirementList()); //объект диалога

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExpirementControl p = new ExpirementControl();
                p.Expirement = c.ExpirementObject;

                
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
            ExpList = new ExpirementList();

            AddModulesFromDefaultFolder();

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

        private ExpirementList GenerateNewExpirementList()
        {
            ExpirementList Lst = new ExpirementList();

            foreach (string p in Dlls)
            {
                Lst.LoadDll(p);
            }
            return Lst;
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpirementStats c = new ExpirementStats(GenerateNewExpirementList()); //объект диалога

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExpirementControl p = new ExpirementControl();
                p.Expirement = c.ExpirementObject;


                Tabs.TabPages.Add("exp" + ExpirementCount, "Эксперимент " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                Tabs.TabPages[ExpirementCount].Focus();

                ExpirementCount++;

            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}