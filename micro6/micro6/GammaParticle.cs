using System;
using System.Collections.Generic;
using System.Text;
using MDK;

namespace micro6
{
    
    class GammaParticle : Particle
    {
        /// <summary>
        /// ������� ������� �����-������ ����� ������� ������������ �����
        /// </summary>
        /// <param name="e">������� ��-0 ������</param>
        /// <param name="MinorFlag">���� true - �� ������� �������� ������ �������� �����</param>
        public void CountEnergy(double e, bool MinorFlag)
        {
            double v = Math.Sqrt(1 - Math.Pow((135 / e), 2));

            if (MinorFlag) this.Energy = e / 2 * (1 - 1 / v);
            else this.Energy = e / 2 * (1 + 1 / v);
        }

        public override string ToString()
        {
            return this.Energy.ToString();
        }
    }
}
