// StatsParameters.cs
using System;
using System.Collections.Generic;
using System.Text;
using ZedGraph;
using System.Drawing;

namespace particles_env
{
    public class StatsParameters
    {
        public List<Color> color = new List<Color>();
        public List<PointPairList> ppList = new List<PointPairList>();
        public List<String> title = new List<String>();
    }
}