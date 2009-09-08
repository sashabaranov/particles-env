using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDK;

namespace particles_env
{
    public partial class ExpStats : Form
    {
        public Experiment ExpirementObject;
        public TabControl tc;
        public ExpStats(ExperimentList e, ref TabControl tabs)
        {
            InitializeComponent();

            ExpirementObject = new Experiment(); /* ������������� ������� ������������, � ������� ����� ��������
                                                    ���������, � ������� ����� ��������� ������� � MainForm    */
            tc = tabs;
            foreach (ExperimentInfo p in e.eList) // ������ ������ ����� �������������
            {
                listBox1.Items.Add(p); // � ������ ����� p.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<ExperimentInfo> experiments = new List<ExperimentInfo>();
            //foreach (ExperimentInfo l in listBox1.SelectedItems)
            //{
            //    experiments.Add(l);
            //}
            StatsParameters myStatsParams = new StatsParameters();
            ExperimentInfo expType = (ExperimentInfo)listBox1.SelectedItem;
            ExperimentControl expCtrl;
            for (int i = 0; i < tc.TabPages.Count;i++)
            {
                expCtrl = (ExperimentControl)tc.TabPages[i].Controls[0];
                /*
                 * TODO: �������� ����� �� �����������.
                 */
                myStatsParams.color[i] = Color.Red;
                myStatsParams.title[i] = string.Format("����������� {0}", i);
                //myStatsParams.ppList[i] = expCtrl.Expirement.Graphics.GetResults();
            }
        }
    }
}