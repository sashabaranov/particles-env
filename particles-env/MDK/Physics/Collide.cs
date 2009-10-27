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
        class Collide
        {
            #region ����
            private double v01; // �������� ������ ������� � �-�������
            private double m1;  // ����� ������(����������) ������� � �-�������
            private double m2;  // ����� ������ �������
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
            }
            #endregion
            private void Calculation()
            {
                double v1 = v01 * (m1 + m2) / m2;
                double V = v1 - v01;
                double V = m1 * v1 / (m1 + m2);
                double v2 = 0;

                double v1a = (m2 / (m1 + m2)) * (v1 - v2) + V;
                double v2a = (m1 / (m1 + m2)) * (v1 - v2) + V;

                double tetaMax = Math.Asin(m2 / m1);

                //���������� ���-���� ���� ����� �� ���������
            }
        }
    }
}
