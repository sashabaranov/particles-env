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

            foreach (ExpirementInfo p in e.eList) // ������ ������ ����� �������������
            {
                listBox1.Items.Add(p); // � ������ ����� p.ToString();
            }
        }

        private void ExperimentStats_Load(object sender, EventArgs e)
        {
     
        }
    }
}