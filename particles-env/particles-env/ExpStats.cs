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

            ExpirementObject = new Experiment(); /* инициализация объекта эксперимента, в который будут вносится
                                                    изминения, и который будет возвращёт обратно в MainForm    */
            tc = tabs;
            foreach (ExperimentInfo p in e.eList) // Создаём список типов экспериментов
            {
                listBox1.Items.Add(p); // в списке будут p.ToString();
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
            String expType = ((ExperimentInfo)listBox1.SelectedItem).Name;
            ExperimentControl expCtrl;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < tc.TabPages.Count;i++)
            {
                expCtrl = (ExperimentControl)tc.TabPages[i].Controls[0];
                MessageBox.Show(expType);
                MessageBox.Show(expCtrl.Expirement.Graphics.ExpirementName);
                if (expCtrl.Expirement.Graphics.ExpirementName!=expType) return;
                myStatsParams.color.Add(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                myStatsParams.title.Add(string.Format("Эксперимент {0}", i));
                PointPairList results = expCtrl.Expirement.Graphics.GetResults();
                if (results.Count == 0)
                {
                    MessageBox.Show("Извините, данный эксперимент не поставляет статистики.");
                    return;
                }
                myStatsParams.ppList.Add(results);
                
            }
            Stats statsWin = new Stats(myStatsParams);
            statsWin.Show();
        }
    }
}