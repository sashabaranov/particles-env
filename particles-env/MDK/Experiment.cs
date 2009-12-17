using System;
using System.Collections.Generic;
using System.Text;

namespace MDK
{
    [Serializable]
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
