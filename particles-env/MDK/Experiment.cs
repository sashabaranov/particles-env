using System;
using System.Collections.Generic;
using System.Text;

namespace MDK
{
    public class Experiment
    {
        /// <summary>
        /// ������������
        /// </summary>
        public GraphicPrimitive Graphics;

        /// <summary>
        /// ���������
        /// </summary>
        public ParameterList pList;

        public Experiment()
        {
            pList = new ParameterList();
        }
        
    }
}
