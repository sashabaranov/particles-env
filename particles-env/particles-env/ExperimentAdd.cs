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
    public partial class ExperimentAdd : Form
    {
        private ExperimentList experimentList;

        public ExperimentAdd()
        {
            InitializeComponent();
        }

        public ExperimentAdd(ExperimentList experimentList)
        {
            InitializeComponent();
            this.experimentList = experimentList;
            experimentAddControl1.SetList(experimentList);
            experimentAddControl1.UserSelected += new ExperimentAddControl.UserSelectedHandler(experimentAddControl_UserSelected);
        }

        void experimentAddControl_UserSelected(object sender, Experiment e)
        {
            this.ExperimentObject = e;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public Experiment ExperimentObject = new Experiment();

        private void ExperimentAdd_Load(object sender, EventArgs e)
        {
            
            /*
            experimentAddControl.SetList(experimentList);
            experimentAddControl.UserSelected += new ExperimentAddControl.UserSelectedHandler(experimentAddControl_UserSelected);

            experimentAddControl.Size = new Size(852, 363);
            this.Controls.Add(experimentAddControl);
            this.Invalidate();
            this.Refresh();*/
        }

        private void experimentAddControl1_Load(object sender, EventArgs e)
        {

        }


    }
}
