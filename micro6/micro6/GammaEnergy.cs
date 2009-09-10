using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MDK;

namespace micro6
{
    public class GammaEnergy : MDK.GraphicPrimitive
    {
        #region Программное
        public string sName = "GammaEnergy";
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
            ParameterListTemplate.Add("Минимальная энергия нейтрального пиона", "ePi0_Min", 136);
            ParameterListTemplate.Add("Максимальная энергия нейтрального пиона", "ePi0_Max", 200);

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

            List<Point> Points = new List<Point>();
            bool flg = new bool();

            for (double energy = lEnergy; energy < hEnergy; energy+=10)
            {
                int[] Gammas = CountGammasEnergy(energy);
                
                Point p1 = new Point( Gammas[0], bottom );
                Point p2 = new Point( Gammas[1], bottom );

                
                for(int i = 0; i < Points.Count; i++)
                {
                    if(Points[i].X > p1.X - 10 || Points[i].X < p1.X + 10 ||
                        Points[i].X > p2.X - 10 || Points[i].X < p2.X + 10)
                    {
                        Point l = Points[i];
                        l.Y -= 10;
                        Points[i] = l;
                        flg = true;
                    }
                }
                if(!flg)
                {
                    Points.Add(p1);
                    Points.Add(p2);
                }
                flg = false;

            }

            string text = "";
            for (int j = 0; j < Points.Count; j++)
            {
                text+= String.Format("{0}: {1}, {2} \n", j, Points[j].X, Points[j].Y);
            }

            System.Windows.Forms.MessageBox.Show(text);
        }



        #endregion

        #region Научное

        double lEnergy;
        double hEnergy;

        

        int[] CountGammasEnergy(double E)
        {
            int m = 135;
            int c = 1;

            double v = Math.Sqrt(1 - (Math.Pow(m, 2) * Math.Pow(c, 4)  / Math.Pow(E, 4))); // скорость нейтрального пиона
            
            //промежуточные результаты
            double b = v / c;

            double e = m * m / Math.Sqrt(1 - b);

            //конечные результаты

            double eMin = e / 2 * (1 - b);
            double eMax = e / 2 * (1 + b);

            int[] ret = { (int)eMin + 200, (int)eMax + 200};
            return ret;

        }

        #endregion
    }
}
