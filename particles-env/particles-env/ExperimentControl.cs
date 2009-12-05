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

            EditDialog.eList = this.Expirement.Graphics.GetParameters(); // ìåòîä, îáðàòíûé SetParameters'ó
            
            if (EditDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.Expirement.pList = EditDialog.eList;

                this.Expirement.Graphics.SetParameters(this.Expirement.pList);
                Refresh();
            }
        }

        private void ExpirementControl_Paint(object sender, PaintEventArgs e)
        {
            if (Drawing == null) Drawing = new Bitmap(this.Width, this.Height);
            if (df)
            {
                Drawing = new Bitmap(this.Width, this.Height);
                
                switch (this.Expirement.Graphics.Needs)
                {
                    case ExpirementNeeds.Normal:
                        PaintEventArgs a = new PaintEventArgs(Graphics.FromImage(Drawing), new Rectangle(new Point(this.Left, this.Top), this.Size));
                        this.Expirement.Graphics.Draw(a);
                        e.Graphics.DrawImage(Drawing, new Point(this.Left, this.Top));
                        df = false;
                        break;

                    case ExpirementNeeds.ZedGraph:
                        this.Expirement.Graphics.Draw(e);
                        df = false;
                        break;

                }

                df = false;
            }
            else
            {
                switch (this.Expirement.Graphics.Needs)
                {
                    case ExpirementNeeds.Normal: 
                        e.Graphics.DrawImage(Drawing, new Point(this.Left, this.Top));  break;
                    case ExpirementNeeds.ZedGraph:  break;
                }
                    
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Expirement.Graphics.SetDrawingBorder(this.Left, this.Top, this.Size);
            df = true;
            Refresh();
        }

        private void ñîõðàíèòüÑêðèíøîòToolStripMenuItem_Click(object sender, EventArgs e)
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


        public void LoadParameters(ParameterList List)
        {
            foreach (ParameterListUnit u in List.Parameters)
            {
                int index = ParametersGrid.Rows.Add();
                ParametersGrid.Rows[index].Cells["Parameters"].Value = u.sName;
                ParametersGrid.Rows[index].Cells["Values"].Value = u.Value;
            }
        }

        private void ParametersGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ParameterName = (string) ParametersGrid.Rows[e.RowIndex].Cells[0].Value;
            //this.Expirement.pList[ParameterName] = (double) ParametersGrid[e.ColumnIndex, e.RowIndex].Value;
            Expirement.pList.Parameters[e.RowIndex].Value = double.Parse((string)ParametersGrid[e.ColumnIndex, e.RowIndex].Value);

            Expirement.Graphics.SetParameters(Expirement.pList);
        }
    }
}
