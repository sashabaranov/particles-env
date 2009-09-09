using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MDK;

namespace micro6
{
    /*
     # Добавить 2 переменные: sName( зачем оно нужно O_o) и ExpirementName(человеческое название эксперимента).
# Добавить метод AddParametersToTemplate, который будет инициализировать шаблон списка параметров ParameterListTemplate
# Добавить конструктор без параметров, с вызовом AddParametersToTemplate
# Перегрузить метод Draw
# Перегрузить метод GetParameters
# Перегрузить метод SetParameters 
     */
    public class GammaEnergy : GraphicPrimitive
    {
        #region Программное
        string sName = "GammaEnergy";
        public string ExpirementName = "Исследование энергии гамма-квантов при расспаде нейтрального пиона";

        public GammaEnergy()
            : base(0, 0, new Size())
        {
            AddParametersToTemplate();
        }

        public GammaEnergy(int Left, int Top, Size Size)
            : base(Left, Top, Size)
        {
            this.Left = Left;
            this.Top = Top;

            this.Size = Size;
            AddParametersToTemplate();
        }

        private void AddParametersToTemplate()
        {
            ParameterListTemplate = new ParameterList();
            ParameterListTemplate.Add("Минимальная энергия нейтрального пиона", "ePi0_Min", 1);
            ParameterListTemplate.Add("Максимальная энергия нейтрального пиона", "ePi0_Max", 1);

        }

        public override void SetParameters(ParameterList pList)
        {
            lEnergy = pList["ePi0_Min"];
            hEnergy = pList["ePi0_Max"];

        }

        public override ParameterList GetParameters()
        {
            ParameterList RetList = ParameterListTemplate;
            RetList["ePi0_Min"] = lEnergy;
            RetList["ePi0_Max"] = hEnergy;

            return RetList;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            int bottom = this.Top + this.Size.Height;
            int g = 10;
            for (double energy = lEnergy; energy < hEnergy; energy+=10)
            {
                int[] Gammas = CountGammasEnergy(energy);

                Point[] DrawPoints = { new Point( bottom , Gammas[0]),
                                       new Point( bottom - g, Gammas[0]),
                                       new Point( bottom - g, Gammas[1]),
                                       new Point( bottom , Gammas[1]) };


                e.Graphics.DrawLines(Pens.DarkBlue, DrawPoints);
                g += 20;

            }
        }



        #endregion

        #region Научное

        double lEnergy;
        double hEnergy;

        

        int[] CountGammasEnergy(double E)
        {
            int m = 1;
            int c = 1;

            double v = Math.Sqrt(1 - (Math.Pow(m, 2) * Math.Pow(c, 4)  / Math.Pow(E, 4))); // скорость нейтрального пиона
            
            //промежуточные результаты
            double b = v / c;

            double e = 135 * 135 / Math.Sqrt(1 - b);

            //конечные результаты

            double eMin = e / 2 * (1 - b);
            double eMax = e / 2 * (1 + b);

            int[] ret = { (int)eMin, (int)eMax };
            return ret;

        }

        #endregion
    }
}
