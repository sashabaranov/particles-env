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
        public Experiment ExperimentObject;
        public TabControl tc;
        public ExpStats(ExperimentList e, ref TabControl tabs)
        {
            InitializeComponent();

            ExperimentObject = new Experiment(); /* инициализация объекта эксперимента, в который будут вносится
                                                    изминения, и который будет возвращёт обратно в MainForm    */
            tc = tabs;
            foreach (ExperimentInfo p in e.eList) // Создаём список типов экспериментов
            {
                listBox1.Items.Add(p); // в списке будут p.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
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
                if (tab.Text == "Стартовая страница") continue;
                expCtrl = (ExperimentControl)tab.Controls.Find("ExpCtrl", true)[0];

                if (expType == expCtrl.Experiment.Graphics.GetType())
                {
                    myStatsParams.color.Add(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    myStatsParams.title.Add(tab.Text);
                    PointPairList results = expCtrl.Experiment.Graphics.GetResults();
                    if (results.Count == 0)
                    {
                        MessageBox.Show("Извините, данный эксперимент не поставляет статистики.");
                        return;
                    }
                    myStatsParams.ppList.Add(results);
                }
                i++;
            }
            Stats statsWin = new Stats(myStatsParams);
            statsWin.Show();
            
        }

        private void ExpStats_Load(object sender, EventArgs e)
        {
            
        }
    }
}