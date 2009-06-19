using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ObjectGraphics;

namespace particles_env
{
    public partial class MainForm : Form
    {
        int ExpirementCount;
        static ExpirementList ExpList;


        public MainForm()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новыйЭкспериментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpirementAdd c = new ExpirementAdd(ExpList); //объект диалога

            ExpirementControl p = new ExpirementControl();

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                p.Expirement = c.ExpirementObject;
                

                Tabs.TabPages.Add("exp" + ExpirementCount, "Эксперимент " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                ExpirementCount++;
            }

        }

        private void addExpirementType_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                ExpList.LoadDll(openFileDialog1.FileName);
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            ExpList = new ExpirementList();
        }

    }
}