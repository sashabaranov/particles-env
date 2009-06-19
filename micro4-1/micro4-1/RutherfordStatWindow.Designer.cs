namespace micro4_1
{
    partial class RutherfordStatWindow
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
            this.zedGraphChart = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphChart
            // 
            this.zedGraphChart.AutoSize = true;
            this.zedGraphChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphChart.Location = new System.Drawing.Point(0, 0);
            this.zedGraphChart.Name = "zedGraphChart";
            this.zedGraphChart.ScrollGrace = 0;
            this.zedGraphChart.ScrollMaxX = 0;
            this.zedGraphChart.ScrollMaxY = 0;
            this.zedGraphChart.ScrollMaxY2 = 0;
            this.zedGraphChart.ScrollMinX = 0;
            this.zedGraphChart.ScrollMinY = 0;
            this.zedGraphChart.ScrollMinY2 = 0;
            this.zedGraphChart.Size = new System.Drawing.Size(533, 377);
            this.zedGraphChart.TabIndex = 0;
            // 
            // RutherfordStatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 377);
            this.Controls.Add(this.zedGraphChart);
            this.Name = "RutherfordStatWindow";
            this.Text = "RutherfordStatWindow";
            this.Load += new System.EventHandler(this.makeChart);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphChart;
    }
}