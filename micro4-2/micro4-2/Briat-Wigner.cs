using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ObjectGraphics;


namespace resonance
{
    class Briat_Wigner : GraphicPrimitive
    {
        #region ����
        /// <summary>
        /// �������
        /// </summary>
        float p;

        /// <summary>
        /// ��������, �� ������� ����������
        /// </summary>
        float l;
        #endregion

        #region ������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="Left">x ������ �������� ����</param>
        /// <param name="Top">y �������� ������ ����</param>
        /// <param name="Size">������</param>
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
        /// �(E)
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
