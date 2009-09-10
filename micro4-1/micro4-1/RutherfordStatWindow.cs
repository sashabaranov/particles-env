using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;


namespace micro4_1
{
    public partial class RutherfordStatWindow : Form
    {
        PointPairList mylist1;
        
        public RutherfordStatWindow()
        {
            InitializeComponent();
            
            
        }

        public void setVars(PointPairList tetaList)
        {
            mylist1 = tetaList;
            
            
        }
        private void makeChart(object sender, EventArgs e)
        {
            // get a reference to the GraphPane

            GraphPane myPane = zedGraphChart.GraphPane;

            // Set the Titles
            

            myPane.Title.Text = "Результаты эксперимента\n(Прицельные раcстояния от "+Form1.bLow+" до "+Form1.bHigh+" на " +Form1.nParticles + " частицах)";
            myPane.XAxis.Title.Text = "Углол рассеивания.";
            myPane.YAxis.Title.Text = "Кол-во попавших частиц.";
            
            
           
            
            // create the curves
            //BarItem myCurve = myPane.AddBar("[ц]V 1ой после столкновения", posle_stolk_1_c, Color.Blue);
            BarItem myCurve = myPane.AddBar("",mylist1, Color.Aqua);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White,
               Color.FromArgb(255, 255, 166), 45.0F);

            zedGraphChart.AxisChange();
            myPane.XAxis.Scale.MinorStepAuto = true;

            myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;

            BarItem.CreateBarLabels(myPane, false, "f0");

        }

        private void makeChart()
        {

        }

        

    }

}