using System;
using System.Collections.Generic;
using System.Text;

namespace MDK
{
    public class Experiment
    {
        /// <summary>
        /// Визуализация
        /// </summary>
        public GraphicPrimitive Graphics;

        /// <summary>
        /// Параметры
        /// </summary>
        public ParameterList pList;

        public Experiment()
        {
            pList = new ParameterList();
        }
        
    }
}
