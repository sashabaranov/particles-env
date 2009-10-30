using System;
using System.Collections.Generic;
using System.Text;

namespace MDK
{
    namespace Physics
    {
        /// <summary>
        /// �����, ��� �������� ������������ ������
        /// </summary>
        public class Collide
        {
            #region ����
            private double v01; // �������� ������ ������� � �-�������
            public  double m1;  // ����� ������(����������) ������� � �-�������
            public double m2;  // ����� ������ �������
            #endregion

            #region ������������
            /// <summary>
            /// </summary>
            /// <param name="a">������� �������</param>
            /// <param name="b">������� �������</param>
            public Collide(Particle a, Particle b)
            {
                v01 = a.V;
                m1 = a.m;

                m2 = b.m;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="v01">�������� ������ ������� � �-�������</param>
            /// <param name="m1">����� ������(����������) ������� � �-�������</param>
            /// <param name="m2">����� ������ �������</param>
            public Collide(double v01, double m1, double m2)
            {
                this.v01 = v01;
                this.m1 = m1;

                this.m2 = m2;
                Calculation();
            }
            #endregion
            private void Calculation()
            {
                v1 = v01 * (m1 + m2) / m2;

                V = v1 - v01;
                double v2 = 0;

                v1a = (m2 / (m1 + m2)) * (v1 - v2) + V;
                v2a = (m1 / (m1 + m2)) * (v1 - v2) + V;

                double X = Math.Asin((v2a * (m1 + m2)) / (2 * m1 * V))*2;

                teta1 = 1 / Math.Atan((m2 * Math.Sign(X)) / (m1 + m2 * Math.Cos(X)));
                teta2 = (Math.PI - X) / 2;
                
                tetaMax = Math.Asin(m2 / m1);

                
                //���������� ���-���� ���� ����� �� ���������
            }

            public double v1;

            public double teta1;
            public double teta2;
            public double tetaMax;

            public double v1a;
            public double v2a;
            public double V;
        }
    }
}
