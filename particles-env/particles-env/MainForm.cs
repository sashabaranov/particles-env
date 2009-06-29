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
        List<string> Dlls;

        public MainForm()
        {
            InitializeComponent();
            Dlls = new List<string>();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Ù‡ÈÎToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ÌÓ‚˚È›ÍÒÔÂËÏÂÌÚToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpirementAdd c = new ExpirementAdd(GenerateNewExpirementList()); //Ó·˙ÂÍÚ ‰Ë‡ÎÓ„‡

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExpirementControl p = new ExpirementControl();
                p.Expirement = c.ExpirementObject;

                
                Tabs.TabPages.Add("exp" + ExpirementCount, "›ÍÒÔÂËÏÂÌÚ " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                Tabs.TabPages[ExpirementCount].Focus();
             
                ExpirementCount++;

            }

        }

        private void addExpirementType_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if(!Dlls.Contains(openFileDialog1.FileName))
                {
                    Dlls.Add(openFileDialog1.FileName);
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            ExpList = new ExpirementList();
        }

        private void ‚˚ıÓ‰ToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}