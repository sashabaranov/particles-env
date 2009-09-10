namespace micro4_1
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
            this.button1 = new System.Windows.Forms.Button();
            this.mev_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.q_input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bl_input = new System.Windows.Forms.TextBox();
            this.particles_num = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bh_input = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mev_input
            // 
            this.mev_input.Location = new System.Drawing.Point(44, 23);
            this.mev_input.Name = "mev_input";
            this.mev_input.Size = new System.Drawing.Size(100, 20);
            this.mev_input.TabIndex = 1;
            this.mev_input.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "v";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Q";
            // 
            // q_input
            // 
            this.q_input.Location = new System.Drawing.Point(44, 47);
            this.q_input.Name = "q_input";
            this.q_input.Size = new System.Drawing.Size(100, 20);
            this.q_input.TabIndex = 4;
            this.q_input.Text = "47";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "b";
            // 
            // bl_input
            // 
            this.bl_input.Location = new System.Drawing.Point(44, 74);
            this.bl_input.Name = "bl_input";
            this.bl_input.Size = new System.Drawing.Size(31, 20);
            this.bl_input.TabIndex = 6;
            this.bl_input.Text = "0";
            this.bl_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // particles_num
            // 
            this.particles_num.Location = new System.Drawing.Point(115, 377);
            this.particles_num.Name = "particles_num";
            this.particles_num.Size = new System.Drawing.Size(100, 20);
            this.particles_num.TabIndex = 8;
            this.particles_num.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество частиц";
            // 
            // bh_input
            // 
            this.bh_input.Location = new System.Drawing.Point(97, 74);
            this.bh_input.Name = "bh_input";
            this.bh_input.Size = new System.Drawing.Size(47, 20);
            this.bh_input.TabIndex = 9;
            this.bh_input.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "—";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Статистика";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Задать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 409);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bh_input);
            this.Controls.Add(this.particles_num);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bl_input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.q_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mev_input);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Рассеяние Резерфорда";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox mev_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox q_input;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bl_input;
        private System.Windows.Forms.TextBox particles_num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bh_input;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

