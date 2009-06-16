namespace resonance
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.p_input = new System.Windows.Forms.TextBox();
            this.draw_button = new System.Windows.Forms.Button();
            this.l_input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "p";
            // 
            // p_input
            // 
            this.p_input.Location = new System.Drawing.Point(36, 21);
            this.p_input.Name = "p_input";
            this.p_input.Size = new System.Drawing.Size(100, 20);
            this.p_input.TabIndex = 1;
            this.p_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(36, 73);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(75, 23);
            this.draw_button.TabIndex = 3;
            this.draw_button.Text = "Рисовать";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // l_input
            // 
            this.l_input.Location = new System.Drawing.Point(36, 47);
            this.l_input.Name = "l_input";
            this.l_input.Size = new System.Drawing.Size(100, 20);
            this.l_input.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "l";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 455);
            this.Controls.Add(this.l_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.p_input);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Визуализация формулы Брейта-Вигнера";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox p_input;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.TextBox l_input;
        private System.Windows.Forms.Label label2;
    }
}

