using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MDK;

namespace particles_env
{
    public partial class ExperimentControl : UserControl
    {
        bool df;
        public Experiment Expirement;

        public ExperimentControl()
        {
            InitializeComponent();
            this.Expirement = new Experiment();
        }

        private void setParameters_Click(object sender, EventArgs e)
        {
            ParametersEdit EditDialog = new ParametersEdit();

            EditDialog.eList = this.Expirement.Graphics.GetParameters(); // метод, обратный SetParameters'у
            
            if (EditDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.Expirement.pList = EditDialog.eList;

                this.Expirement.Graphics.SetParameters(this.Expirement.pList);
                Refresh();
            }
        }

        private void ExpirementControl_Paint(object sender, PaintEventArgs e)
        {
            if (df)
            {
                this.Expirement.Graphics.Draw(e);
                if (this.Expirement.Graphics.ComponentFlag)
                {
                    this.Controls.Add(this.Expirement.Graphics.ctrl);
                }
                df = false;
                
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Expirement.Graphics.SetDrawingBorder(this.Left, this.Top, this.Size);
            df = true;
            Refresh();
        }
    }
}
