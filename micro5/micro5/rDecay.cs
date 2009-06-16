using System;
using System.Collections.Generic;
using System.Text;
using ObjectGraphics;
using System.Drawing;

namespace micro5
{
    using Particle;
 
    class rDecay : GraphicPrimitive
    {
#region ���������

        //������
        float E0;      //[�] �������
        float p0;      //[�] �������
        float V;       //[�] ��������
        float m;       // �����
        float teta;    // ���� ������
        float tetaMax; // ������������ ���� ������

        //���������
        float px;
        float py;

        float smesh_x;
        float smesh_y;

        float x0;
        float y0;

#endregion

#region ������


        public rDecay(int Left, int Top) : base(Left,Top)
        {
            this.Left = Left;
            this.Top = Top;
        }

        public void SetParameters(float Energy0, float Impulse0, float Speed)
        {
            E0 = Energy0;
            p0 = Impulse0;
            V = Speed;

            Counting();
        }

        private void Counting()
        {
            float c = (float)Math.Sqrt((double)(1 - V * V)); //�������� �������

            px = p0 / c;
            py = p0;

            m = (float)Math.Sqrt(E0 * E0 - p0 * p0);

            tetaMax = (float)Math.Asin((double)((p0 * Math.Sqrt(1 - V * V)) / (m * V)));

            smesh_x = E0 * V / c;
            smesh_y = 0;

            x0 = px * px  / (smesh_x);
            y0 = (float)(Math.Tan((float)tetaMax) * x0);
            //teta = CountTeta(); - �������� �����
        }


        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
 	        // ��� ���������, px � py = �������,  tetamax - ������������ ����
            e.Graphics.DrawEllipse(Pens.Black, this.Left , this.Top , px*2, py*2);
             
            e.Graphics.DrawLine(Pens.Blue, this.Left + px , this.Top + py, this.Left + px - smesh_x, this.Top + py - smesh_y);

            float x, y; // ��� ���������
            for (float i = 0; i < this.Left + px; i += 0.1f)
            {
                x = i;
                y = (float)(Math.Tan((float)tetaMax) * i);

                if (( (Math.Pow((x - (this.Left + px)), 2)) / (px * px)) 
                    + 
                      ((Math.Pow((y - (this.Top + py)), 2)) / (py * py)) == 1) break;

                e.Graphics.DrawEllipse(Pens.Red, this.Left + px - smesh_x + x, this.Top + py - y, 1, 1);
            }
            
            //e.Graphics.DrawLine(Pens.Red, this.Left + px - smesh_x, this.Top + py - smesh_y, this.Left + px -x0, this.Top + py - y0);
        
        }


#endregion


        #region �� ����������
        /*
        public float CountTeta()
        {
            return Math.Acos((double)());
        }*/
        #endregion
    }
}
