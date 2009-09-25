using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDK;
using ZedGraph;

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
            Type expType = ((ExperimentInfo)listBox1.SelectedItem).GraphicsObj.GetType();
           
            ExperimentControl expCtrl;
            Random rnd = new Random(DateTime.Now.Millisecond);
            int i = 0;
            foreach (TabPage tab in tc.TabPages)
            {
                
                expCtrl = (ExperimentControl)tab.Controls[0];

                if (expType == expCtrl.Expirement.Graphics.GetType())
                {
                    myStatsParams.color.Add(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    myStatsParams.title.Add(string.Format("����������� {0}", i));
                    PointPairList results = expCtrl.Expirement.Graphics.GetResults();
                    if (results.Count == 0)
                    {
                        MessageBox.Show("��������, ������ ����������� �� ���������� ����������.");
                        return;
                    }
                    myStatsParams.ppList.Add(results);
                }
                i++;
            }
            Stats statsWin = new Stats(myStatsParams);
            statsWin.Show();
        }
    }
}