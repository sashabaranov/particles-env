using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace particles_env
{
    using Expirement;

    public partial class ExpirementControl : UserControl
    {
        bool df;
        public Expirement Expirement;

        public ExpirementControl()
        {
            InitializeComponent();
            this.Expirement = new Expirement();
        }

        private void setParameters_Click(object sender, EventArgs e)
        {
            ParametersEdit EditDialog = new ParametersEdit();

            EditDialog.eList = this.Expirement.pList;
            
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
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Expirement.Graphics.SetDrawingBorder(this.Left + this.Width/2, this.Top + this.Height/2, this.Size);
            df = true;
            Refresh();
        }
    }
}
