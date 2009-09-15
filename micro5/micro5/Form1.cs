using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace micro5
{
    public partial class Form1 : Form
    {
        bool draw_flag = false; // true - draw something
                // false - stay still
        rDecay Decay;
        public Form1()
        {
            InitializeComponent();
            Decay = new rDecay(groupBox3.Left + 10, groupBox3.Top + 50);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float V = float.Parse(vBox.Text);
            float e0 = float.Parse(e0Box.Text);
            float p0 = float.Parse(pBox.Text);
            if ( V  <  p0 / e0 )
            {
                MessageBox.Show("V < v0\nПожалуйста, введите другие данные.");
                return;
            }

            Decay.SetParameters(float.Parse(e0Box.Text), float.Parse(pBox.Text), float.Parse(vBox.Text));

            draw_flag = true;
            Refresh();
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw_flag = false;
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            if (draw_flag)
            {
                Decay.Draw(e);
            }
        }
    }
}