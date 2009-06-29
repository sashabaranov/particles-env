using System;
using System.Collections.Generic;
using System.Text;

namespace RutherfordScatteringLib
{
    using Particle;
    class AlphaParticle : Particle
    {
        float r = 0;
        float f = 0;
        float fx = 0;
        float fy = 0;

        float ay = 0;
        float ax = 0;

        float fi = 0;
        float dx = 0;
        float dy = 0;

        public static Particle Nucl; //внимание, классы в c# - ссылочные => копирования объектов не происходит.

        #region Constructing
        public AlphaParticle(Particle Prototype,float b)
        {
            //this.Nucl = Nucl;

            this.x = Prototype.x;
            this.y = Prototype.y;

            this.vx = Prototype.vx;
        }
        #endregion

        #region Counting
        public void Move()
        {
            dx = Nucl.x - this.x;
            dy = Nucl.y - this.y;

            r = (float)Math.Sqrt((double)(dx * dx + dy * dy));

            fi = (float)Math.Asin((double)(dy / r));

            f = (float)((2 * Nucl.Q * 200) / (4 * (float)Math.PI * 8.85 * r * r));

            fx = (float)f * (float)Math.Cos((double)fi);
            fy = (float)f * (float)Math.Sin((double)fi);

            ax = -fx / 6.7f;
            ay = fy / 6.7f;

            this.vy += ay;
            this.y -= (float) this.vy;

            this.vx += ax;
            this.x += (float) this.vx;
        }
        #endregion

    }
}
