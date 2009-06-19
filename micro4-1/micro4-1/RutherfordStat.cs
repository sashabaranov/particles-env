using System;
using System.Collections.Generic;
using System.Text;
using ObjectGraphics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using ZedGraph;


namespace micro4_1
{
    using Particle;

    public partial class RutherfordStat : GraphicPrimitive
    {
        public Particle Alpha;
        public Particle Nucl;
        float[] b;
        float tetaLow, tetaHigh;
        PointPairList tetaList;
       
        float[] teta_array;
            
        public RutherfordStat(int Left, int Top, Size Size) : base(Left, Top, Size)
        {
            this.Left = Left;
            this.Top = Top;

            this.Size = Size;
            tetaList = new PointPairList();
            tetaLow = 0;
            tetaHigh = (float)(Math.PI/2);
        }

        public void setBArray(float[] b_new)
        {
            this.b = b_new;
        }

        private void makeTeta()
        {
            tetaList.Clear(); 
            teta_array = new float[6];
            float curr_teta;
            foreach (float b_elem in b)
            {
                curr_teta = CountTeta(b_elem);
                if (curr_teta >= 0 && curr_teta <= Math.PI / 3)
                    teta_array[0]++;
                else if (curr_teta > Math.PI / 3 && curr_teta <= 2 * Math.PI / 3)
                    teta_array[1]++;
                else if (curr_teta > 2 * Math.PI / 3 && curr_teta <= Math.PI)
                    teta_array[2]++;
                else if (curr_teta > Math.PI && curr_teta <= 4 * Math.PI / 3)
                    teta_array[3]++;
                else if (curr_teta > 4 * Math.PI / 3 && curr_teta <= 5 * Math.PI / 3)
                    teta_array[4]++;
                else if (curr_teta > 5 * Math.PI / 3 && curr_teta <= 2 * Math.PI)
                    teta_array[5]++;
            }

            for (int i = 0; i < 6; i++)
            {
                tetaList.Add((i * Math.PI / 3)*(180/Math.PI), teta_array[i]);
            }
            
        }

        /// <summary>
        /// ћетод рисовани€
        /// </summary>
        /// <param name="e"></param>
        public void Draw()
        {
            makeTeta();
            RutherfordStatWindow cfrm = new RutherfordStatWindow();
            cfrm.setVars(tetaList);
            
            cfrm.Show();
        }

        public float Actg(double value)
        {
            return ((float)Math.PI / 2 - (float)Math.Atan(value));
        }

        private float CountTeta(float b)
        {

            //return 20 * Actg((float)((Alpha.m * b * (Alpha.V * Alpha.V) / (Z * 2 * 2.56 * (float)Math.Pow(10, -3))));
            // z - зар€д €дра
            const double p = 1; //пор€док, на что домножать
            //double r = Alpha.m * Alpha.V * Alpha.V * b;


            //return (2 * Actg(p * r));
            return (2 * Actg( (Alpha.m * b * Alpha.V * Alpha.V) / (2 *  Nucl.Q))); 
        }
    }
}
