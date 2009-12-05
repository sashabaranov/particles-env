namespace particles_env
{
    partial class ExperimentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.setParameters = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.сохранить—криншотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ParametersGrid = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.Parameters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // setParameters
            // 
            this.setParameters.Location = new System.Drawing.Point(3, 3);
            this.setParameters.Name = "setParameters";
            this.setParameters.Size = new System.Drawing.Size(121, 23);
            this.setParameters.TabIndex = 0;
            this.setParameters.Text = "«адать параметры";
            this.setParameters.UseVisualStyleBackColor = true;
            this.setParameters.Click += new System.EventHandler(this.setParameters_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "–исовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранить—криншотToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 26);
            // 
            // сохранить—криншотToolStripMenuItem
            // 
            this.сохранить—криншотToolStripMenuItem.Image = global::particles_env.Properties.Resources.monitor;
            this.сохранить—криншотToolStripMenuItem.Name = "сохранить—криншотToolStripMenuItem";
            this.сохранить—криншотToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.сохранить—криншотToolStripMenuItem.Text = "—охранить скриншот";
            this.сохранить—криншотToolStripMenuItem.Click += new System.EventHandler(this.сохранить—криншотToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "»зображение Bitmap|*.bmp";
            // 
            // ParametersGrid
            // 
            this.ParametersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParametersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameters,
            this.Values});
            this.ParametersGrid.Location = new System.Drawing.Point(399, 0);
            this.ParametersGrid.Name = "ParametersGrid";
            this.ParametersGrid.Size = new System.Drawing.Size(244, 361);
            this.ParametersGrid.TabIndex = 2;
            this.ParametersGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParametersGrid_CellEndEdit);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // Parameters
            // 
            this.Parameters.HeaderText = "ѕараметры";
            this.Parameters.Name = "Parameters";
            this.Parameters.ReadOnly = true;
            // 
            // Values
            // 
            this.Values.HeaderText = "«начени€";
            this.Values.Name = "Values";
            // 
            // ExperimentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParametersGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setParameters);
            this.Name = "ExperimentControl";
            this.Size = new System.Drawing.Size(643, 364);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ExpirementControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExperimentControl_MouseClick);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setParameters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранить—криншотToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView ParametersGrid;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
    }
}
