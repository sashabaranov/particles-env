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
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.сохранить—криншотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ParametersGrid = new System.Windows.Forms.DataGridView();
            this.Parameters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descriptionLabel = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(570, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
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
            this.ParametersGrid.AllowUserToAddRows = false;
            this.ParametersGrid.AllowUserToDeleteRows = false;
            this.ParametersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ParametersGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ParametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParametersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameters,
            this.Values});
            this.ParametersGrid.EnableHeadersVisualStyles = false;
            this.ParametersGrid.Location = new System.Drawing.Point(570, 238);
            this.ParametersGrid.Name = "ParametersGrid";
            this.ParametersGrid.RowHeadersVisible = false;
            this.ParametersGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ParametersGrid.Size = new System.Drawing.Size(200, 329);
            this.ParametersGrid.TabIndex = 2;
            this.ParametersGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParametersGrid_CellEndEdit);
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
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.descriptionLabel);
            this.groupBox1.Location = new System.Drawing.Point(570, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ќписание";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionLabel.Location = new System.Drawing.Point(5, 22);
            this.descriptionLabel.Multiline = true;
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.ReadOnly = true;
            this.descriptionLabel.Size = new System.Drawing.Size(186, 175);
            this.descriptionLabel.TabIndex = 0;
            // 
            // ExperimentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ParametersGrid);
            this.Controls.Add(this.button1);
            this.Name = "ExperimentControl";
            this.Size = new System.Drawing.Size(770, 570);
            this.Load += new System.EventHandler(this.ExperimentControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ExperimentControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExperimentControl_MouseClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранить—криншотToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView ParametersGrid;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox descriptionLabel;
    }
}
