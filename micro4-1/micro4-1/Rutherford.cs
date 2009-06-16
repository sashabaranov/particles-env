using System;
using System.Collections.Generic;
using System.Text;
using ObjectGraphics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace micro4_1
{
    using Particle;

    public partial class Rutherford  : GraphicPrimitive
    {
        #region Поля

        /// <summary>
        /// Объект альфа-частицы
        /// </summary>
        public Particle Alpha;

        /// <summary>
        /// Объект ядра
        /// </summary>
        public Particle Nucl;

        /// <summary>
        /// Все наши частицы
        /// </summary>
        List<AlphaParticle> Particles = new List<AlphaParticle>();

        /// <summary>
        /// Нижняя граница b
        /// </summary>
        public float bLow;

        /// <summary>
        /// Верхняя граница b
        /// </summary>
        public float bHigh;

        /// <summary>
        /// Массив прицельных расстояний
        /// </summary>
        public float[] bArray;
        #endregion

        #region Методы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Left">x левого верхнего угла</param>
        /// <param name="Top">y левого верхнего угла</param>
        public Rutherford(int Left, int Top, Size Size) : base(Left, Top, Size)
        {
            this.Left = Left;
            this.Top = Top;

            this.Size = Size;
        }


        public void SetParticles(Particle Alpha, Particle Nucl)
        {
            this.Alpha = Alpha;
            this.Nucl = Nucl;

            //инициализируемся
            Nucl.x = this.Left + this.Size.Width * 2 / 3;
            Nucl.y = this.Top + this.Size.Height * 2 / 3;

            /*Alpha.x = Nucl.x - 200;
            Alpha.y = Nucl.y - b;*/

            //Alpha.vx = Alpha.vx;
            
        }


        /// <summary>
        /// Метод рисования
        /// </summary>
        /// <param name="e"></param>
        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            

            #region Old Trash
            /*
            float r = 0;
            float f = 0;
            float fx = 0;
            float fy = 0;

            float ay = 0;
            float ax = 0;

            float fi = 0;
            float dx = 0;
            float dy = 0;

            for (int i = 0; i < 500; i++)
            {
                dx = Nucl.x - Alpha.x;
                dy = Nucl.y - Alpha.y;

                r = (float)Math.Sqrt((double)(dx * dx + dy * dy));

                fi = (float)Math.Asin((double)(dy / r));
                
                f = (float)((2 * Nucl.Q* 200 ) / (4 * (float)Math.PI * 8.85 * r * r));

                fx = (float)f * (float)Math.Cos((double)fi);
                fy = (float)f * (float)Math.Sin((double)fi);

                ax = -fx / 6.7f;
                ay = fy / 6.7f;

                Alpha.vy += ay;
                Alpha.y -= Alpha.vy;

                Alpha.vx += ax;
                Alpha.x += Alpha.vx;

                //e.Graphics.DrawRectangle(Pens.Red, Alpha.x, Alpha.y, 1, 1);
                DrawParticle(Alpha, e.Graphics, Pens.Red);
                DrawParticle(Nucl, e.Graphics, Pens.Blue);
                
            }*/
            #endregion
            //AlphaParticle p = new AlphaParticle(ref Nucl, Alpha, b);

            for (int i = 0; i < 500; i++)
            {
                foreach (AlphaParticle a in Particles)
                {
                    a.Move();

                    DrawParticle(a, e.Graphics, Pens.Red);
                   
                }
                DrawParticle(Nucl, e.Graphics, Pens.Blue);
            }
            Particles.Clear();
        }

        public void AddParticles(float[] bArray)
        {
            Random rnd = new Random();

            for (int i = 0; i < bArray.Length; i++)
            {
                Particle m = new Particle();
                m.x = Nucl.x - 200;
                m.y = Nucl.y - bArray[i];

                m.vx = Alpha.vx;

                AlphaParticle p = new AlphaParticle(m, bArray[i]);

                Particles.Add(p);
            }
        }

        public void DrawParticle(Particle p, Graphics g, Pen pen)
        {
            //g.FillEllipse(pen.Brush, p.x, p.y, 10, 10);
            g.DrawRectangle(pen, p.x, p.y, 1, 1);

        }
        #endregion
    }
}
