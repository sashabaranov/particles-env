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

        // Needs.OpenGL
        double[] cameraPos = { 0, 0, 0 };
        double[] targetPos = { 0, 0, 1, 1 }; // targetPos[3] - zoom
        double[] rotateA = { 0, 0, 0 };

        public ExperimentControl()
        {
            InitializeComponent();
            this.Experiment = new Experiment();
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
                        _Size = new Size(this.Width - ParametersGrid.Width, this.Height - 26);
                        ZedGraph.ZedGraphControl zgc = (ZedGraph.ZedGraphControl)this.Controls.Find("ZedGraphControl", true)[0];
                        zgc.Size = _Size;
                        this.Experiment.Graphics.Draw(e);
                        df = false;
                        break;
                    
                    case ExperimentNeeds.Graph:
                        ZedGraph.ZedGraphControl graph = (ZedGraph.ZedGraphControl)this.Controls.Find("ZedGraphControl", true)[0];
                        ZedGraph.PointPairList points = this.Experiment.Graphics.GetPoints();
                        ZedGraph.LineItem curve;
                        graph.GraphPane.CurveList.Clear();
                        curve = graph.GraphPane.AddCurve("Ãðàôèê", points, Color.Blue, ZedGraph.SymbolType.None);
                        curve.Symbol.Fill = new ZedGraph.Fill(Color.White);
                        curve.Symbol.Size = 2;
                        //curve.Line.IsSmooth = true;
                        //curve.Line.SmoothTension = 0.3f;
                        _Size = new Size(this.Width - ParametersGrid.Width, this.Height - 26);
                        graph.Size = _Size;
                        graph.AxisChange();
                        graph.Refresh();
                        break;
                    case ExperimentNeeds.OpenGL:
                        _Size = new Size(this.Width - ParametersGrid.Width, this.Height - 26);
                        Tao.Platform.Windows.SimpleOpenGlControl tctrl = (Tao.Platform.Windows.SimpleOpenGlControl)this.Controls.Find("TaoControl", true)[0];
                        tctrl.Size = _Size;
                        this.Experiment.Graphics.GL_init(_Size.Width, _Size.Height);
                        this.Experiment.Graphics.GL_camera(cameraPos, targetPos, rotateA);
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

        private void ñîõðàíèòüÑêðèíøîòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.Abort)
            {           
                Drawing.Save(saveFileDialog1.FileName);
            }            
        }


        private void ExperimentControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Experiment.Graphics.Needs == ExperimentNeeds.OpenGL) return;
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
            try
            {
                string ParameterName = (string)ParametersGrid.Rows[e.RowIndex].Cells[0].Value;

                string NewValue = (string)ParametersGrid[e.ColumnIndex, e.RowIndex].Value;
                NewValue.Replace(".", ",");

                bool parsed = double.TryParse(NewValue, out Experiment.pList.Parameters[e.RowIndex].Value);
                if (!parsed) throw new Exception("Can't parse!");
                Experiment.Graphics.SetParameters(Experiment.pList);
            }
            catch(Exception ex) 
            {
                ParametersGrid[e.ColumnIndex, e.RowIndex].Value = Experiment.pList.Parameters[e.RowIndex].dValue;
                Experiment.pList.Parameters[e.RowIndex].Value = Experiment.pList.Parameters[e.RowIndex].dValue;
            }
        }

        int prev_x, prev_y;
        const double MouseDragSpeed = 0.5;
        const double MouseRotateSpeed = 0.3;
        enum CameraMode { Drag, Rotate, Zoom, None };
        CameraMode CMode = CameraMode.None;
        public void OGL_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    CMode = CameraMode.Drag;
                    break;
                case MouseButtons.Right:
                    CMode = CameraMode.Rotate;
                    break;
            }
            prev_x = e.X;
            prev_y = e.Y;
        }

        public void OGL_MouseUp(object sender, MouseEventArgs e)
        {
            CMode = CameraMode.None;
        }

        public void OGL_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            targetPos[3] -= e.Delta;
            
            Refresh();
        }

        public void OGL_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
          
            switch (e.KeyCode)
            {
                case Keys.Z:
                    targetPos[3] += 0.1;
                    break;
                case Keys.X:
                    targetPos[3] -= 0.1;
                    break;
            }
            df = true;
            Refresh();
            
        }

        public void OGL_MouseMove(object sender, MouseEventArgs e)
        {
            double dx, dy;
            switch (CMode)
            {
                   
                case CameraMode.None:
                    return;
                    break;
                case CameraMode.Drag:
                    dx = e.X - prev_x;
                    dx *= MouseDragSpeed;

                    dy = e.Y - prev_y;
                    dy *= MouseDragSpeed;
                    
                    cameraPos[0] += dx;
                    cameraPos[1] += dy;

                    targetPos[0] += dx;
                    targetPos[1] += dy;

                    df = true;
                    Refresh();
                    break;
                case CameraMode.Rotate:
                    dx = e.X - prev_x;
                    dx *= MouseRotateSpeed;

                    dy = e.Y - prev_y;
                    dy *= MouseRotateSpeed;

                    rotateA[0] += dy;
                    rotateA[1] -= dx;

                    /*if (rotateA[0] > 90)
                        rotateA[0] = 90;
                    if (rotateA[0] < -90)
                        rotateA[0] = -90;*/

                    df = true;
                    Refresh();
                    break;
            }
            prev_x = e.X;
            prev_y = e.Y;
        }

        internal void LoadExperiment(MDK.Experiment c)
        {
            descriptionLabel.Text = c.Graphics.GetAbout().Description;
            this.Experiment = c;
        }

        private void ExperimentControl_Load(object sender, EventArgs e)
        {
            //descriptionLabel.BackColor = SystemColors.Window;
        }
    }
}
