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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpirementAdd c = new ExpirementAdd(GenerateNewExpirementList()); //������ �������

            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExpirementControl p = new ExpirementControl();
                p.Expirement = c.ExpirementObject;

                
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
            ExpList = new ExpirementList();

            AddModulesFromDefaultFolder();

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

        private ExpirementList GenerateNewExpirementList()
        {
            ExpirementList Lst = new ExpirementList();

            foreach (string p in Dlls)
            {
                Lst.LoadDll(p);
            }
            return Lst;
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ExpirementStats c = new ExpirementStats(GenerateNewExpirementList()); //������ �������
            ExpStats c = new ExpStats(GenerateNewExpirementList());
            if (c.ShowDialog() != DialogResult.Cancel)
            {
                ExpirementControl p = new ExpirementControl();
                p.Expirement = c.ExpirementObject;


                Tabs.TabPages.Add("exp" + ExpirementCount, "����������� " + ExpirementCount);
                Tabs.TabPages[ExpirementCount].Controls.Add(p);
                Tabs.TabPages[ExpirementCount].Focus();

                ExpirementCount++;

            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl tab = new TabControl();
            for (int i = 0; i < tab.TabPages.Count; i++)
            {
                MessageBox.Show(tab.TabPages[i].Name);
            }

        }
    }
}