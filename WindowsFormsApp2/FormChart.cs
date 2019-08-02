using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class FormChart : Form
    {
        public List<List<double>> charTemps = new List<List<double>>();

       // public FormChart(List<List<double>> info)
        public FormChart()
        {
            //charTemps2 = info;
            InitializeComponent();
            
           // label1.Text = info;
        }
        public void CreateChart()
        {
            ChartArea chartArea1 = new ChartArea();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(chartArea1);

            Legend legend1 = new Legend();
            chart1.Legends.Clear();
            chart1.Legends.Add(legend1);

            chart1.Series.Clear();

            double min = 1000;
            double max = -1000;

            Console.WriteLine(charTemps.Count);
            Console.WriteLine(charTemps[0].Count);
            for (int j = 0; j < charTemps.Count; j++)
            {

                Series series1 = new Series();
                series1.ChartType = SeriesChartType.Line;
                series1.Name = "Seria" + j;
                chart1.Series.Add(series1);
                for (int i = 0; i < charTemps[j].Count; i++)
                {
                    chart1.Series["Seria" + j].Points.AddY(charTemps[j][i]);
                    if (min > charTemps[j][i]) min = charTemps[j][i];
                    if (max < charTemps[j][i]) max = charTemps[j][i];

                }

            }
            //Console.WriteLine("min");
            //Console.WriteLine(min);
            //Console.WriteLine("max");
            //Console.WriteLine(max);

            chart1.ChartAreas[0].AxisY.Minimum = min - (int)(min * 0.1);
            chart1.ChartAreas[0].AxisY.Maximum = max + (int)(max * 0.1);
        }
        private void FormChart_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //chart1.ChartAreas.Clear();
            // chart1.Legends.Clear();
            charTemps.Clear();
            chart1.Series.Clear();

        }
    }
}
