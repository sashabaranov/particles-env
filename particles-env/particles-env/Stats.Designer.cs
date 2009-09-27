namespace particles_env
{
    partial class Stats
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
            this.experimentGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // experimentGraph
            // 
            this.experimentGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.experimentGraph.Location = new System.Drawing.Point(0, 0);
            this.experimentGraph.Name = "experimentGraph";
            this.experimentGraph.ScrollGrace = 0;
            this.experimentGraph.ScrollMaxX = 0;
            this.experimentGraph.ScrollMaxY = 0;
            this.experimentGraph.ScrollMaxY2 = 0;
            this.experimentGraph.ScrollMinX = 0;
            this.experimentGraph.ScrollMinY = 0;
            this.experimentGraph.ScrollMinY2 = 0;
            this.experimentGraph.Size = new System.Drawing.Size(600, 350);
            this.experimentGraph.TabIndex = 0;
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.experimentGraph);
            this.MaximizeBox = false;
            this.Name = "Stats";
            this.ShowIcon = false;
            this.Text = "Stats";
            this.Load += new System.EventHandler(this.Stats_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl experimentGraph;
    }
}