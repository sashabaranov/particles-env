namespace particles_env
{
    partial class ParametersEdit
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
            this.DoneButton = new System.Windows.Forms.Button();
            this.eDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(12, 494);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 2;
            this.DoneButton.Text = "Готово";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // eDescription
            // 
            this.eDescription.AutoSize = true;
            this.eDescription.Location = new System.Drawing.Point(151, 12);
            this.eDescription.Name = "eDescription";
            this.eDescription.Size = new System.Drawing.Size(57, 13);
            this.eDescription.TabIndex = 3;
            this.eDescription.Text = "Описание";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 114);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ParametersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 529);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.eDescription);
            this.Controls.Add(this.DoneButton);
            this.MaximizeBox = false;
            this.Name = "ParametersEdit";
            this.ShowIcon = false;
            this.Text = "Задать параметры";
            this.Load += new System.EventHandler(this.ParametersEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label eDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}