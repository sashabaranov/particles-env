using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace MDK
{
    public class LegendDrawer
    {
        Dictionary<Color, String> Trajectories = new Dictionary<Color, string>();
        int Left = 0;
        int Top = 0;
        string description;


        public LegendDrawer(int left, int top, string topDescription)
        {
            this.Left = left;
            this.Top = top;

            this.description = topDescription;
        }

        public void AddTrajectory(Color col, String description)
        {
            Trajectories.Add(col, description);
        }


        public void Draw(Graphics g)
        {
            Font dFont = SystemFonts.DefaultFont;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            g.DrawString(description, dFont, Brushes.Black, Left, Top);


            int y = Top + 20;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (Color c in Trajectories.Keys)
            {

                g.DrawString(Trajectories[c], dFont, new SolidBrush(c), Left, y);

                y += 15;
            }
        }
    }
}
