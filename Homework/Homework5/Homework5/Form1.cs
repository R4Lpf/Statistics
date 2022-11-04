using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Security.Cryptography.RandomNumberGenerator;

namespace Homework5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Random r = new Random();
        public int Gen()
        {
            return r.Next(10, 289);
        }

        bool vert = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (vert)
            {
                this.chart1.Series["Dati"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                vert = false;
            }
            else {
                this.chart1.Series["Dati"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                vert = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Gen();
            int s = Gen();
            this.pictureBox1.Width = a;
            this.pictureBox1.Height = s;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            this.chart1.Series["Dati"].Points.AddXY("Base", a);
            this.chart1.Series["Dati"].Points.AddXY("Height", s);
            this.chart1.Series["Dati"].Points.AddXY("Diagonal", Math.Sqrt((a*a)+(s*s)));
            this.chart1.Series["Dati"].Points.AddXY("Perimeter", a+a+s+s);
            // this.chart1.Series["Dati"].Points.AddXY("Area", a*s);
        }
    }
}
