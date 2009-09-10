namespace micro3
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedChart = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedChart
            // 
            this.zedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedChart.Location = new System.Drawing.Point(0, 0);
            this.zedChart.Name = "zedChart";
            this.zedChart.ScrollGrace = 0;
            this.zedChart.ScrollMaxX = 0;
            this.zedChart.ScrollMaxY = 0;
            this.zedChart.ScrollMaxY2 = 0;
            this.zedChart.ScrollMinX = 0;
            this.zedChart.ScrollMinY = 0;
            this.zedChart.ScrollMinY2 = 0;
            this.zedChart.Size = new System.Drawing.Size(770, 433);
            this.zedChart.TabIndex = 0;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 433);
            this.Controls.Add(this.zedChart);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedChart;
    }
}