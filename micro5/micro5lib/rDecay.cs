using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MDK;

namespace micro5lib
{
    public static class info
    {
        public static string ExpirementName = "�������������� ������ �������";
        public static string ClassName = "rDecay";
    }

    public class gType : GraphicPrimitive
    {
        static public string ExpirementName = "�������������� ������ �������";
        static public string sName = "rDecay";
        
        #region ���������

        //������
        double E0;      //[�] �������
        double p0;      //[�] �������
        double V;       //[�] ��������
        double m;       // �����
        double teta;    // ���� ������
        double tetaMax; // ������������ ���� ������

        //���������
        double px;
        double py;

        double smesh_x;
        double smesh_y;

        double x0;
        double y0;


#endregion
        #region ������

        /// <summary>
        /// ��� ���� �� ���������
        /// </summary>
        public  gType() : base(0,0,new Size()) 
        {
            AddParametersToTemplate();
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="Left">���������� x ������ �������� ����</param>
        /// <param name="Top">���������� y ������ �������� ����</param>
        /// <param name="_Size">������</param>
        public gType(int Left, int Top, Size _Size) : base(Left,Top, _Size)
        {
            this.Left = Left;
            this.Top = Top;
            this.Size = _Size;
            AddParametersToTemplate();
        }

     
        /// <summary>
        /// ������� ���� ����., �������� � ��� �� ����� �������
        /// </summary>
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

        public override void SetParameters(ParameterList pList)
        {
            E0 = pList["E0"];
            p0 = pList["p0"];
            V = pList["V"];

            Counting();
        }

        public override ParameterList GetParameters()
        {
            ParameterList ReturnList = this.ParameterListTemplate;

            ReturnList["E0"] = E0;
            ReturnList["p0"] = p0;
            ReturnList["V"] = V;
            return ReturnList;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="e">�������</param>
        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
 	        // ��� ���������, px � py = �������,  tetamax - ������������ ����
            ////////////////e.Graphics.DrawEllipse(Pens.Black, (float)this.Left, (float)this.Top, (float)(px * 2), (float)(py * 2));

            e.Graphics.DrawLine(Pens.Blue, (float)(this.Left + px), (float)(this.Top + py), (float)(this.Left + px - smesh_x), (float)(this.Top + py - smesh_y));

            float x, y; // ��� ���������
            for (float i = 0; i < smesh_x - x0; i+=0.1f)
            {
                x = i;
                y = (float)(Math.Tan((float)tetaMax) * i);


                e.Graphics.DrawEllipse(Pens.Red, (float)(this.Left + px - smesh_x + x), (float)(this.Top + py - y), 1, 1);
            }
            
            //e.Graphics.DrawLine(Pens.Red, this.Left + px - smesh_x, this.Top + py - smesh_y, this.Left + px -x0, this.Top + py - y0);
        
        }

        /// <summary>
        /// ����� ������ ����������
        /// </summary>
        private void AddParametersToTemplate()
        {
            ParameterListTemplate = new ParameterList(); //�� GraphicsPrimitive
            ParameterListTemplate.Add("������� ��������� ������� � �-�������", "E0", 0);
            ParameterListTemplate.Add("������� ��������� ������� � �-�������", "p0", 0);
            ParameterListTemplate.Add("�������� ��������� ������� � �-�������", "V", 0);
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
