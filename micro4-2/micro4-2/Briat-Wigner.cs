using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ObjectGraphics;


namespace resonance
{
    class Briat_Wigner : GraphicPrimitive
    {
        #region Поля
        /// <summary>
        /// Импульс
        /// </summary>
        float p;

        /// <summary>
        /// Величина, не имеющая объяснения
        /// </summary>
        float l;
        #endregion

        #region Методы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Left">x левого верхнего угла</param>
        /// <param name="Top">y верхнего левого угла</param>
        /// <param name="Size">Размер</param>
        public Briat_Wigner(int Left, int Top, Size Size) : base(Left, Top)
        {
            this.Left = Left;
            this.Top = Top;

            this.Size = Size;
        }

        public void SetParameters(float p, float l)
        {
            this.p = p;
            this.l = l;
        }


        /// <summary>
        /// Ъ(E)
        /// </summary>
        /// <param name="E"></param>
        /// <returns></returns>
        float S(float E)
        {
            float lambda = 1 / p;
            lambda *= lambda; // ^2
            float g = 0.25f; // g^2/4

            float gPart = g / (E + g);

            return (float)(2 * (float)Math.PI * lambda * (2 * l + 1) * gPart);
        }

        public override void  Draw(System.Windows.Forms.PaintEventArgs e)
        {
            for (float E = 0; E < this.Size.Width; E++)
            {
                e.Graphics.DrawRectangle(Pens.Red, E+this.Left , S(E)*10 + this.Top, 1, 1);
            }
        }

        #endregion




    }
}
