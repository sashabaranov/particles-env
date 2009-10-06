namespace particles_env
{
    partial class ParameterControl
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
            this.ParameterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ParameterName
            // 
            this.ParameterName.AutoSize = true;
            this.ParameterName.Location = new System.Drawing.Point(3, 18);
            this.ParameterName.Name = "ParameterName";
            this.ParameterName.Size = new System.Drawing.Size(35, 13);
            this.ParameterName.TabIndex = 0;
            this.ParameterName.Text = "label1";
            // 
            // ParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParameterName);
            this.Name = "ParameterControl";
            this.Size = new System.Drawing.Size(287, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ParameterName;

    }
}
