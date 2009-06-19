using System;
using System.Collections.Generic;
using System.Text;
using ObjectGraphics;
using System.Drawing;

namespace micro5lib
{
    using Particle;
    using ParameterList;

    public static class info
    {
        public static string ExpirementName = "Релятивистский распад частицы";
        public static string ClassName = "rDecay";
    }

    public class gType : GraphicPrimitive
    {
        static public string ExpirementName = "Релятивистский распад частицы";
        static public string sName = "rDecay";
        
        #region Параметры

        //физика
        double E0;      //[ц] энергия
        double p0;      //[ц] импульс
        double V;       //[л] скорость
        double m;       // масса
        double teta;    // угол разлёта
        double tetaMax; // максимальный угол разлёта

        //рисование
        double px;
        double py;

        double smesh_x;
        double smesh_y;

        double x0;
        double y0;


#endregion
        #region Методы

        /// <summary>
        /// Без него не загрузить
        /// </summary>
        public  gType() : base(0,0,new Size()) 
        {
            AddParametersToTemplate();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Left">Координата x левого верхнего угла</param>
        /// <param name="Top">Координата y левого верхнего угла</param>
        /// <param name="_Size">Размер</param>
        public gType(int Left, int Top, Size _Size) : base(Left,Top, _Size)
        {
            this.Left = Left;
            this.Top = Top;
            this.Size = _Size;
            AddParametersToTemplate();
        }

     
        /// <summary>
        /// Подсчет тета макс., смещения а так же точек касания
        /// </summary>
        private void Counting()
        {
            float c = (float)Math.Sqrt((double)(1 - V * V)); //сокращая расчёты

            px = p0 / c;
            py = p0;

            m = (float)Math.Sqrt(E0 * E0 - p0 * p0);

            tetaMax = (float)Math.Asin((double)((p0 * Math.Sqrt(1 - V * V)) / (m * V)));

            smesh_x = E0 * V / c;
            smesh_y = 0;

            x0 = px * px  / (smesh_x);
            y0 = (float)(Math.Tan((float)tetaMax) * x0);
            //teta = CountTeta(); - Добавить позже
        }

        public override void SetParameters(ParameterList pList)
        {
            E0 = pList["E0"];
            p0 = pList["p0"];
            V = pList["V"];

            Counting();
        }

        /// <summary>
        /// Прорисовка
        /// </summary>
        /// <param name="e">графика</param>
        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
 	        // тут рисование, px и py = полуоси,  tetamax - максимальный угол
            ////////////////e.Graphics.DrawEllipse(Pens.Black, (float)this.Left, (float)this.Top, (float)(px * 2), (float)(py * 2));

            e.Graphics.DrawLine(Pens.Blue, (float)(this.Left + px), (float)(this.Top + py), (float)(this.Left + px - smesh_x), (float)(this.Top + py - smesh_y));

            float x, y; // для рисования
            for (float i = 0; i < smesh_x - x0; i+=0.1f)
            {
                x = i;
                y = (float)(Math.Tan((float)tetaMax) * i);


                e.Graphics.DrawEllipse(Pens.Red, (float)(this.Left + px - smesh_x + x), (float)(this.Top + py - y), 1, 1);
            }
            
            //e.Graphics.DrawLine(Pens.Red, this.Left + px - smesh_x, this.Top + py - smesh_y, this.Left + px -x0, this.Top + py - y0);
        
        }

        /// <summary>
        /// Задаёт список параметров
        /// </summary>
        private void AddParametersToTemplate()
        {
            ParameterListTemplate = new ParameterList(); //из GraphicsPrimitive
            ParameterListTemplate.Add("Энергия распадной частицы в ц-системе", "E0", 0);
            ParameterListTemplate.Add("Импульс распадной частицы в ц-системе", "p0", 0);
            ParameterListTemplate.Add("Скорость распадной частицы в л-системе", "V", 0);
        }

#endregion
        #region Не доработано
        /*
        public float CountTeta()
        {
            return Math.Acos((double)());
        }*/
        #endregion
    }
}
