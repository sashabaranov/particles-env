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
    public partial class ExperimentStats : Form
    {
        public ExperimentStats(ExpirementList e)
        {
            InitializeComponent();

            foreach (ExpirementInfo p in e.eList) // Создаём список типов экспериментов
            {
                listBox1.Items.Add(p); // в списке будут p.ToString();
            }
        }

        private void ExperimentStats_Load(object sender, EventArgs e)
        {
     
        }
    }
}