using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;



namespace particles_env
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
        }
        
        List<StatsParameters> ParametersList = new List<StatsParameters>();

        /*public void SetParameters(params StatsParameters[] sp)
        {
            foreach (StatsParameters Parameter in sp)
            {
                ParametersList.Add(Parameter);
            }
        }*/

        private void makeChart()
        {
            // get a reference to the GraphPane

            GraphPane myPane = experimentGraph.GraphPane;

            // Set the Titles

            myPane.Title.Text = "Результаты эксперимента";
            myPane.XAxis.Title.Text = "Величина";
            myPane.YAxis.Title.Text = "Эксперипент";

            
            // create the curves
            foreach(StatsParameters Parameter in ParametersList)
            {
                BarItem myCurve = myPane.AddBar(Parameter.title, Parameter.pList, Parameter.color);
            }

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White,
               Color.FromArgb(255, 255, 0), 45.0F);

            experimentGraph.AxisChange();

            myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;

            BarItem.CreateBarLabels(myPane, false, "f0");

        }

        private void Stats_Load(object sender, EventArgs e)
        {
            makeChart();
        }
    }
}