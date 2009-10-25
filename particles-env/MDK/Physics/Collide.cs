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
            public Collide(Particle a, Particle b)
            {
                double v = a.Speed - b.Speed;

                //скорости в ц-системе
                double v10 = (b.m * v) / (a.m + b.m);
                double v20 = -(a.m * v) / (a.m + b.m);

            }
        }
    }
}
