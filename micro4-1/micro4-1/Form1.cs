using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace micro4_1
{
    
    using Particle;
    public partial class Form1 : Form
    {
        public Rutherford Scene;
        bool df; // draw flag

        #region stats
        public RutherfordStat SceneStat;
        #endregion

        Particle Alpha;
        Particle Nucl;

        float[] bArray;

        public static int bLow;
        public static int bHigh;
        public static int nParticles;

        public Form1()
        {
            InitializeComponent();

            Scene = new Rutherford(10, 10, this.Size);
            
            #region stats
            Alpha = new Particle();
            Nucl = new Particle();
            SceneStat = new RutherfordStat(10, 10, this.Size);
            #endregion

             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            df = true;
            Refresh();
        }

        private float[] GenerateB()
        {
            Random rnd = new Random();
            float[] bArray = new float[int.Parse(particles_num.Text)];
            
            for (int i = 0; i < bArray.Length; i++)
            {
                bArray[i] = rnd.Next(int.Parse(bl_input.Text), int.Parse(bh_input.Text));
            }

            return bArray;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (df)
            {
              Scene.Draw(e);
              df = false;
            }
        }


        #region stats

        private void button2_Click(object sender, EventArgs e)
        {
            Alpha.V = float.Parse(mev_input.Text);
            Alpha.m = 6.7f;
            SceneStat.Alpha = this.Alpha;
            SceneStat.Nucl = this.Nucl;
            SceneStat.setBArray(bArray);
            SceneStat.Draw();
        }


        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            bArray = GenerateB();

            Nucl = new Particle();
            Nucl.ElectricCharge = float.Parse(q_input.Text);

            Alpha.vx = float.Parse(mev_input.Text);

            AlphaParticle.Nucl = Nucl;
            Scene.SetParticles(Alpha, Nucl);

            Scene.AddParticles(bArray);

            bLow = int.Parse(bl_input.Text);
            bHigh = int.Parse(bh_input.Text);
            nParticles = int.Parse(particles_num.Text);
        }
    }
}