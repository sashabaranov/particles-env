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
        class Collide
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
                double V = v1 - v01;
                double V = m1 * v1 / (m1 + m2);
                double v2 = 0;

                double v1a = (m2 / (m1 + m2)) * (v1 - v2) + V;
                double v2a = (m1 / (m1 + m2)) * (v1 - v2) + V;

                double tetaMax = Math.Asin(m2 / m1);

                //возвращать что-либо пока нигде не требуется
            }
        }
    }
}
