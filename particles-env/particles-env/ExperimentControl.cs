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
        Bitmap Drawing;

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
            if(Drawing == null) Drawing = new Bitmap(this.Width,this.Height);

            if (df)
            {
                Drawing = new Bitmap(this.Width, this.Height);

                PaintEventArgs a = new PaintEventArgs(Graphics.FromImage(Drawing), new Rectangle(new Point(this.Left, this.Top), this.Size));
                this.Expirement.Graphics.Draw(a);
                e.Graphics.DrawImage(Drawing, new Point(this.Left, this.Top));

                if (this.Expirement.Graphics.ComponentFlag)
                {
                    if (Controls.Count >= 3) Controls.Remove(this.Controls[2]);
                    this.Controls.Add(this.Expirement.Graphics.ctrl);
                }
                df = false;

            }
            else
            {
                e.Graphics.DrawImage(Drawing, new Point(this.Left, this.Top));
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Expirement.Graphics.SetDrawingBorder(this.Left, this.Top, this.Size);
            df = true;
            Refresh();
        }

        private void сохранить—криншотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.Abort)
            {           
                Drawing.Save(saveFileDialog1.FileName);
            }

            
        }


        private void ExperimentControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) contextMenuStrip1.Show(this, e.Location);
        }
    }
}
