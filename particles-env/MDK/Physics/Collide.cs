using System;
using System.Collections.Generic;
using System.Text;

namespace MDK
{
    namespace Physics
    {
        /// <summary>
        /// Класс, для рассчёта столкновения частиц
        /// </summary>
        public class Collide
        {
            #region Поля
            private double v01; // скорость первой частицы в ц-системе
            private double m1;  // масса первой(движущейся) частицы в ц-системе
            private double m2;  // масса второй частицы
            #endregion

            #region Конструкторы
            /// <summary>
            /// </summary>
            /// <param name="a">Летящая частица</param>
            /// <param name="b">Стоящая частица</param>
            public Collide(Particle a, Particle b)
            {
                v01 = a.V;
                m1 = a.m;

                m2 = b.m;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="v01">скорость первой частицы в ц-системе</param>
            /// <param name="m1">масса первой(движущейся) частицы в ц-системе</param>
            /// <param name="m2">масса второй частицы</param>
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
                
                V = v1 - v01;
                double v2 = 0;

                v1a = (m2 / (m1 + m2)) * (v1 - v2) + V;
                v2a = (m1 / (m1 + m2)) * (v1 - v2) + V;

                double X = Math.Asin((v2a * (m1 + m2)) / (2 * m1 * V))*2;

                teta1 = 1 / Math.Atan((m2 * Math.Sign(X)) / (m1 + m2 * Math.Cos(X)));
                teta2 = (Math.PI - X) / 2;
                
                tetaMax = Math.Asin(m2 / m1);

                //возвращать что-либо пока нигде не требуется
            }

            public double teta1;
            public double teta2;
            public double tetaMax;

            public double v1a;
            public double v2a;
            public double V;
        }
    }
}
