using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MDK;
using Tao.OpenGl;

namespace particles_env
{
    public partial class ExperimentControl : UserControl
    {
        bool df;
        public Experiment Experiment;
        Bitmap Drawing;

        public ExperimentControl()
        {
            InitializeComponent();
            this.Experiment = new Experiment();
        }

        private void setParameters_Click(object sender, EventArgs e)
        {
            ParametersEdit EditDialog = new ParametersEdit();

            EditDialog.eList = this.Experiment.Graphics.GetParameters(); // метод, обратный SetParameters'у
            
            if (EditDialog.ShowDialog() != DialogResult.Cancel)
            {
                this.Experiment.pList = EditDialog.eList;

                this.Experiment.Graphics.SetParameters(this.Experiment.pList);
                Refresh();
            }
        }

        private void ExperimentControl_Paint(object sender, PaintEventArgs e)
        {
            if (Drawing == null) Drawing = new Bitmap(this.Width, this.Height);
            if (df)
            {
                Drawing = new Bitmap(this.Width, this.Height);
                
                switch (this.Experiment.Graphics.Needs)
                {
                    case ExperimentNeeds.Normal:
                        Size _Size = new Size(this.Width - ParametersGrid.Width, this.Height);
                        PaintEventArgs a = new PaintEventArgs(Graphics.FromImage(Drawing), new Rectangle(new Point(this.Left, this.Top), _Size));
                        this.Experiment.Graphics.Draw(a);
                        e.Graphics.DrawImage(Drawing, new Point(this.Left, this.Top));
                        df = false;
                        break;

                    case ExperimentNeeds.ZedGraph:
                        this.Experiment.Graphics.Draw(e);
                        df = false;
                        break;
                    
                    case ExperimentNeeds.Graph:
                        ZedGraph.ZedGraphControl graph = (ZedGraph.ZedGraphControl)this.Controls.Find("ZedGraphControl", true)[0];
                        ZedGraph.PointPairList points = this.Experiment.Graphics.GetPoints();
                        ZedGraph.LineItem curve;
                        graph.GraphPane.CurveList.Clear();
                        curve = graph.GraphPane.AddCurve("График", points, Color.Blue, ZedGraph.SymbolType.None);
                        curve.Symbol.Fill = new ZedGraph.Fill(Color.White);
                        curve.Symbol.Size = 2;
                        //curve.Line.IsSmooth = true;
                        //curve.Line.SmoothTension = 0.3f;
                        _Size = new Size(this.Width - ParametersGrid.Width, this.Height);
                        graph.Size = _Size;
                        graph.AxisChange();
                        graph.Refresh();
                        break;
                    case ExperimentNeeds.OpenGL:
                        _Size = new Size(this.Width - ParametersGrid.Width, this.Height);
                        Tao.Platform.Windows.SimpleOpenGlControl tctrl = (Tao.Platform.Windows.SimpleOpenGlControl)this.Controls.Find("TaoControl", true)[0];
                        tctrl.Size = _Size;
                        
                        Gl.glMatrixMode(Tao.OpenGl.Gl.GL_PROJECTION);
                        Gl.glLoadIdentity();
                        Gl.glViewport(0, 0, tctrl.Width, tctrl.Height);
                        Glu.gluPerspective(45, tctrl.Width / tctrl.Height, 0.1, 200);
                        Gl.glOrtho(-tctrl.Width / 2, tctrl.Width / 2, -tctrl.Height / 2, tctrl.Height / 2, 0, 200);

                        Gl.glMatrixMode(Tao.OpenGl.Gl.GL_MODELVIEW);
                        Gl.glLoadIdentity();

                        // setting up light
                        float[] mat_specular = { 1, 1, 1, 1 };
                        float[] mat_shininess = { 100.0f };
                        float[] light_position = { -100, 50, -70 };
                        float[] light_white = { 1, 1, 1, 1 };
                        Gl.glShadeModel(Gl.GL_SMOOTH);
                        Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat_specular);
                        Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, mat_shininess);
                        Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
                        Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_white);
                        Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light_white);
                        Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light_white);
                        Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, new float[] { 0.1f, 0.1f, 0.1f, 1.0f});

                        Gl.glEnable(Gl.GL_LIGHTING); Gl.glEnable(Gl.GL_LIGHT0); Gl.glEnable(Gl.GL_DEPTH_TEST);

                        this.Experiment.Graphics.Draw(e);
                        df = false;
                        tctrl.Invalidate();
                        break;

                }

                df = false;
            }
            else
            {
                switch (this.Experiment.Graphics.Needs)
                {
                    case ExperimentNeeds.Normal: 
                        e.Graphics.DrawImage(Drawing, new Point(this.Left, this.Top));  break;
                    case ExperimentNeeds.ZedGraph:  break;
                }
                    
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Experiment.Graphics.SetDrawingBorder(this.Left, this.Top, this.Size);
            df = true;
            Refresh();
        }

        private void сохранитьСкриншотToolStripMenuItem_Click(object sender, EventArgs e)
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
            Experiment.pList = List;
            foreach (ParameterListUnit u in List.Parameters)
            {
                int index = ParametersGrid.Rows.Add();
                ParametersGrid.Rows[index].Cells["Parameters"].Value = u.sName;
                ParametersGrid.Rows[index].Cells["Parameters"].ToolTipText = u.Name;

                ParametersGrid.Rows[index].Cells["Values"].Value = u.Value;
                ParametersGrid.Rows[index].Cells["Values"].ToolTipText = u.Name;
            }
        }

        private void ParametersGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ParameterName = (string) ParametersGrid.Rows[e.RowIndex].Cells[0].Value;
           
            
            if(!double.TryParse((string)ParametersGrid[e.ColumnIndex, e.RowIndex].Value, out Experiment.pList.Parameters[e.RowIndex].Value))
            {
                MessageBox.Show("Неправильно введён параметр!");
                ParametersGrid[e.ColumnIndex, e.RowIndex].Value = Experiment.pList.Parameters[e.RowIndex].dValue;
                Experiment.pList.Parameters[e.RowIndex].Value = Experiment.pList.Parameters[e.RowIndex].dValue;
            }
            /*
            try
            {
                value = double.Parse((string)ParametersGrid[e.ColumnIndex, e.RowIndex].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильно введено значение!");
            }
            */

            Experiment.Graphics.SetParameters(Experiment.pList);
        }
    }
}
