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
        /// ������������
        /// </summary>
        public GraphicPrimitive Graphics;

        /// <summary>
        /// ���������
        /// </summary>
        public ParameterList pList;

        public Expirement()
        {
            pList = new ParameterList();
        }
    }
}
