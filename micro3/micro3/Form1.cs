using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace micro3
{
    public partial class Form1 : Form
    {
        //все переменные

        //общее
        double V;
        double m1, m2;

        //ц
        double v01 = 1; //v02 = 0 - мешеншь
        double v01a;

        //л
        double v1, v2;
        double v1a, v2a;
        
        double tetaMax;

        bool DrawFlag;

        // Результаты эксперимента

        PointPairList posle_stolk_1_c = new PointPairList();
        PointPairList posle_stolk_2_c = new PointPairList();

        PointPairList posle_stolk_1_l = new PointPairList();
        PointPairList posle_stolk_2_l = new PointPairList();

        PointPairList tetaMax_res = new PointPairList();

        int numOfExp;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            numOfExp = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m1 = Convert.ToDouble(textBox1.Text);
            m2 = Convert.ToDouble(textBox2.Text);

            v01 = Convert.ToDouble(textBox3.Text);

            //V   = //Convert.ToDouble(textBox4.Text);

            Calculation();
            DrawFlag = true;
            Refresh();
            ChartForm cfrm = new ChartForm();
            cfrm.getVars(posle_stolk_1_c, posle_stolk_2_c, posle_stolk_1_l, posle_stolk_2_l, tetaMax_res);
            cfrm.Show();
        }

        private void Calculation()
        {
            v1 = v01 * (m1 + m2) / m2;
            V = v1 -  v01;
            //V = m1 * v1 / (m1 + m2);
            v2 = 0;
           
            v1a = (m2 / (m1 + m2)) * (v1-v2) + V;
            v2a = (m1 / (m1 + m2)) * (v1-v2) + V;

            tetaMax = Math.Asin(m2 / m1);

            string msg = "Результаты\n";
            msg += string.Format("[ц]Скорость первой после столкновения: {0}\n", v1a - V);
            msg += string.Format("[ц]Скорость второй после столкновения: {0}\n", v2a - V);

            posle_stolk_1_c.Add(numOfExp, v1a - V);
            posle_stolk_2_c.Add(numOfExp, v2a - V);

            msg += string.Format("[л]Скорость первой после столкновения: {0}\n", v1a);
            msg += string.Format("[л]Скорость второй после столкновения: {0}\n", v2a);

            posle_stolk_1_l.Add(numOfExp, v1a);
            posle_stolk_2_l.Add(numOfExp, v2a);

            msg += string.Format("[л]Тета максимальное: {0}\n", tetaMax);

            tetaMax_res.Add(numOfExp, tetaMax * 10 );

            label4.Text = msg;

            // эксперимент закончен. визуализация.
            numOfExp++;   
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            if (DrawFlag && (V > v01))
            {

                Pen okr = Pens.Black;  // Для окружности
                Pen vekt = Pens.Blue;  // Для векторов
                Pen txt = Pens.RoyalBlue; // Для надписей
                Pen vekt2 = Pens.Purple; // Для векторов №2

                float r = (float)v01; // Радиус

                // Основной круг...
                e.Graphics.DrawEllipse(okr, 250 - r, 250 - r, 2 * r, 2 * r);
                // .. с радиусом v01.
                e.Graphics.DrawLine(vekt, 250.5f, 250.5f, 250.5f + r, 250.5f);
                Font z = new Font("Tahoma",10);
                e.Graphics.DrawString("v01", z, txt.Brush, 250.5f + r / 2, 250.5f - 30);
                e.Graphics.DrawEllipse(okr, 249.5f, 249.5f, 1, 1); // точка в середине

                // V > v01
                e.Graphics.DrawLine(vekt2, 249.5f, 250f, 249.5f - (float)V, 250f);
                e.Graphics.DrawString("V", z, txt.Brush, 250.5f - (float)(V / 2), 250.5f - 20);

                // Проводим касательную..
                float new_y = (float)(Math.Sin(tetaMax) * Math.Cos(tetaMax) * V);
                float new_x = (float)(V - Math.Pow(Math.Cos(tetaMax), 2) * V);
                e.Graphics.DrawLine(vekt2, 249.5f - (float)V, 250, 250 - new_x, 250 - new_y);
                //DrawFlag = false;

                // Рисование charts
                //e.Graphics.FillRectangle(Pens.Red.Brush, chartBox.Left, chartBox.Top, 20, (float)tetaMax*100);

            }
            //else if(DrawFlag) MessageBox.Show("V должно быть больше v01", "Ошибка");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}