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
            df = true;
        }

        private void ExpirementControl_Paint(object sender, PaintEventArgs e)
        {
            if (df) Expirement.Graphics.Draw(e);
        }
    }
}
