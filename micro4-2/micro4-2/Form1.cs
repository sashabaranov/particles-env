using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace resonance
{
    public partial class Form1 : Form
    {
        Briat_Wigner Scene;

        bool df;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void draw_button_Click(object sender, EventArgs e)
        {
            Scene = new Briat_Wigner(this.Size.Width/2, 0, new Size(300,500));

            Scene.SetParameters(float.Parse(p_input.Text),float.Parse(l_input.Text));

            df = true;
            Refresh();
        }

       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (df)
            {
                Scene.Draw(e);
                df = false;
            }
        }

        
    }
}