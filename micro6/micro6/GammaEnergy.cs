using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MDK;
using System.IO;

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
            ParameterListTemplate.Add("Минимальная энергия π- мезона", "ePi0_Min", 136);
            ParameterListTemplate.Add("Максимальная энергия π- мезона", "ePi0_Max", 200);
            ParameterListTemplate.Add("Количество бросков", "Throws", 300);
        }

        public override void SetParameters(ParameterList pList)
        {
            lEnergy = pList["ePi0_Min"];
            hEnergy = pList["ePi0_Max"];
            throws  = (int)pList["Throws"];
        }

        public override ParameterList GetParameters()
        {
            ParameterList RetList = ParameterListTemplate;
            RetList["ePi0_Min"] = lEnergy;
            RetList["ePi0_Max"] = hEnergy;
            RetList["Throws"]   = throws;
            return RetList;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            GammaPair.bottom = this.Top + this.Size.Height;
            GammaPair.middle = this.Size.Width / 2;
            
            Random rnd = new Random(); 
            List<GammaPair> Pairs = new List<GammaPair>();

            for (int ThrowCounter = 0; ThrowCounter < throws; ThrowCounter++)
            {
                double energy = (double)rnd.Next((int)lEnergy, (int)hEnergy);

                GammaPair p = new GammaPair(energy);

                bool flg = false;
                //if (Pairs.Contains(p)) Pairs[Pairs.IndexOf(p)].ParticlesCount++;
                foreach(GammaPair g in Pairs)
                {
                    if (g == p)
                    {
                        g.ParticlesCount += 20;
                        flg = true;
                    }
                }

                if (!flg)  Pairs.Add(p);
                
            }
            string text = "";
            

            foreach (GammaPair l in Pairs)
            {
                DrawGate(l.PointsToDraw(), e.Graphics);
                text += l.ToString();
            }
            File.WriteAllText("particles-micro6.txt", text);

        }

        private void DrawGate(Point[] points, Graphics e)
        {
            e.DrawLines(Pens.Purple, points);
        }

        #endregion

        #region Научное

        double lEnergy;
        double hEnergy;
        int throws;




        #endregion
    }
}
