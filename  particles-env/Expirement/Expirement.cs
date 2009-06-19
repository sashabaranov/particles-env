using System;
using System.Collections.Generic;
using System.Text;
using ObjectGraphics;


namespace Expirement
{
    using ParameterList;

    public class Expirement
    {
        /// <summary>
        /// Визуализация
        /// </summary>
        public GraphicPrimitive Graphics;

        /// <summary>
        /// Параметры
        /// </summary>
        public ParameterList pList;

        public Expirement()
        {
            pList = new ParameterList();
        }
    }
}
