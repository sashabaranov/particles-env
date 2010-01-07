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
        double[] targetPos = { 0, 0, 5 };
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
                        //Glu.gluPerspective(60, tctrl.Width / tctrl.Height, 0.1, 100);
                        Gl.glOrtho(-tctrl.Width / 2, tctrl.Width / 2, -tctrl.Height / 2, tctrl.Height / 2, -500, 500);

                        Gl.glMatrixMode(Tao.OpenGl.Gl.GL_MODELVIEW);
                        Gl.glLoadIdentity();

                        Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);        // Clear Screen And Depth Buffer
                        Gl.glLoadIdentity();  
                        
                        //camera
                        Glu.gluLookAt(cameraPos[0], cameraPos[1], cameraPos[2], targetPos[0], targetPos[1], targetPos[2], 
                            0, 1, 0); // еденичный вектор смотрит вверх
                        Gl.glRotated(-rotateA[0], 1, 0, 0);
                        Gl.glRotated(rotateA[1], 0, 1, 0);
                        Gl.glRotated(-rotateA[2], 0, 0, 1);
                        //Gl.glTranslated(0, 0, -10);
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
            string ParameterName = (string) ParametersGrid.Rows[e.RowIndex].Cells[0].Value;
            
            if(!double.TryParse((string)ParametersGrid[e.ColumnIndex, e.RowIndex].Value, out Experiment.pList.Parameters[e.RowIndex].Value))
            {
                MessageBox.Show("Неправильно введён параметр!");
                ParametersGrid[e.ColumnIndex, e.RowIndex].Value = Experiment.pList.Parameters[e.RowIndex].dValue;
                Experiment.pList.Parameters[e.RowIndex].Value = Experiment.pList.Parameters[e.RowIndex].dValue;
            }

            Experiment.Graphics.SetParameters(Experiment.pList);
        }

        int prev_x, prev_y;
        const double MouseDragSpeed = 0.5;
        const double MouseRotateSpeed = 0.3;
        enum CameraMode { Drag, Rotate, None };
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

                    if (rotateA[0] > 90)
                        rotateA[0] = 90;
                    if (rotateA[0] < -90)
                        rotateA[0] = -90;

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
