using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZedGraph;

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
        
        public bool IsWiderThan(GammaPair s)
        {
            if (this.Minor.Energy < s.Minor.Energy &&
                this.Major.Energy > s.Major.Energy) return true;
            else return false;
        }

        public bool IsHigherThan(GammaPair s)
        {
            if (this.ParticlesCount > s.ParticlesCount) return true;
            else return false;
        }


        public PointPairList PointsToDraw()
        {

            PointPairList Points = new PointPairList(); 
           
            Points.Add((int)(Minor.Energy+middle), bottom);
            Points.Add((int)(Minor.Energy+middle), bottom - ParticlesCount);
            Points.Add((int)(Major.Energy+middle), bottom - ParticlesCount);
            Points.Add((int)(Major.Energy+middle), bottom);
                           
            
            return Points;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}\n", Minor.ToString(), Major.ToString(), ParticlesCount);
        }
    }
}
