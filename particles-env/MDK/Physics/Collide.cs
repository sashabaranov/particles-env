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
            public Collide(Particle a, Particle b)
            {
                double v = a.Speed - b.Speed;

                //�������� � �-�������
                double v10 = (b.m * v) / (a.m + b.m);
                double v20 = -(a.m * v) / (a.m + b.m);

            }
        }
    }
}
