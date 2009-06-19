namespace particles_env
{
    partial class ExpirementControl
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
            this.SuspendLayout();
            // 
            // setParameters
            // 
            this.setParameters.Location = new System.Drawing.Point(3, 3);
            this.setParameters.Name = "setParameters";
            this.setParameters.Size = new System.Drawing.Size(121, 23);
            this.setParameters.TabIndex = 0;
            this.setParameters.Text = "Задать параметры";
            this.setParameters.UseVisualStyleBackColor = true;
            this.setParameters.Click += new System.EventHandler(this.setParameters_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Рисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExpirementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setParameters);
            this.Name = "ExpirementControl";
            this.Size = new System.Drawing.Size(643, 364);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ExpirementControl_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setParameters;
        private System.Windows.Forms.Button button1;
    }
}
