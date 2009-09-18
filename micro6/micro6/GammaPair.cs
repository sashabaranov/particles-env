using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace micro6
{
    class GammaPair
    {
        public GammaParticle Minor;
        public GammaParticle Major;

        public int ParticlesCount;
        public static int bottom;
        public static int middle;

        public GammaPair(double energy)
        {
            Minor = new GammaParticle();
            Minor.CountEnergy(energy, true);

            Major = new GammaParticle();
            Major.CountEnergy(energy, false);
        }
        
        public static bool operator ==(GammaPair First, GammaPair Second)
        {
            if (First.Major.Energy == Second.Major.Energy &&
                First.Minor.Energy == Second.Minor.Energy) return true;
            else return false;
        }

        public static bool operator !=(GammaPair First, GammaPair Second)
        {
            if (First.Major.Energy != Second.Major.Energy &&
                First.Minor.Energy != Second.Minor.Energy) return true;
            else return false;
        }

        public static bool operator >(GammaPair First, GammaPair Second)
        {
            if (Second.Minor.Energy > First.Minor.Energy
                &&
                Second.Major.Energy < First.Major.Energy
                &&
                Second.ParticlesCount > First.ParticlesCount) return true;
            else return false;
        }
        public static bool operator <(GammaPair First, GammaPair Second)
        {
            if (Second.Minor.Energy < First.Minor.Energy
                &&
                Second.Major.Energy > First.Major.Energy
                &&
                Second.ParticlesCount < First.ParticlesCount) return true;
            else return false;
        }


        public Point[] PointsToDraw()
        {

            Point[] Points = { 
                                new Point((int)(Minor.Energy+middle), bottom),
                                new Point((int)(Minor.Energy+middle), bottom - ParticlesCount),
                                new Point((int)(Major.Energy+middle), bottom - ParticlesCount),
                                new Point((int)(Major.Energy+middle), bottom)
                             };
            return Points;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}\n", Minor.ToString(), Major.ToString(), ParticlesCount);
        }
    }
}
