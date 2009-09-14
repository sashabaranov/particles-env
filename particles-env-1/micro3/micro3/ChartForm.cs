using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ZedGraph;
using System.Windows.Forms;

namespace micro3
{
    public partial class ChartForm : Form
    {
        PointPairList posle_stolk_1_c = new PointPairList();
        PointPairList posle_stolk_2_c = new PointPairList();

        PointPairList posle_stolk_1_l = new PointPairList();
        PointPairList posle_stolk_2_l = new PointPairList();

        PointPairList tetaMax_res = new PointPairList();
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            makeChart();
        }


        public void getVars(PointPairList l1, PointPairList l2, PointPairList l3,
            PointPairList l4, PointPairList l5)
        {
            posle_stolk_1_c = l1;
            posle_stolk_2_c = l2;

            posle_stolk_1_l = l3;
            posle_stolk_2_l = l4;

            tetaMax_res = l5;
        }

        private void makeChart()
        {
            // get a reference to the GraphPane

            GraphPane myPane = zedChart.GraphPane;

            // Set the Titles

            myPane.Title.Text = "Результаты эксперимента";
            myPane.XAxis.Title.Text = "Величина";
            myPane.YAxis.Title.Text = "Номер эксперипента";
            
            // create the curves
            BarItem myCurve = myPane.AddBar("[ц]V 1ой после столкновения", posle_stolk_1_c, Color.Blue);
            BarItem myCurve2 = myPane.AddBar("[ц]V 2ой после столкновения", posle_stolk_2_c, Color.Red);
            BarItem myCurve3 = myPane.AddBar("[л]V 1ой после столкновения", posle_stolk_1_l, Color.Green);
            BarItem myCurve4 = myPane.AddBar("[л]V 2ой после столкновения", posle_stolk_2_l, Color.Yellow);
            BarItem myCurve5 = myPane.AddBar("[x10]tetaMax", tetaMax_res, Color.RosyBrown);
 

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White,
               Color.FromArgb(255, 255, 166), 45.0F);

            zedChart.AxisChange();

            myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;

            BarItem.CreateBarLabels(myPane, false, "f0");
            
        }
    }
}