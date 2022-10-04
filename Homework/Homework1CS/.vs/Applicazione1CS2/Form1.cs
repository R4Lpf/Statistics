using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Security.Cryptography.RandomNumberGenerator;

namespace Applicazione1CS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        public int Gen(){
            return r.Next(1,7);
        }

        int[] count = { 0, 0, 0, 0, 0, 0 };

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int a = Gen();
            int s = Gen();
            int d = Gen();
            int f = Gen();
            int g = Gen();
            int h = Gen();
            label1.Text = a.ToString();
            label2.Text = s.ToString();
            label3.Text = d.ToString();
            label4.Text = f.ToString();
            label5.Text = g.ToString();
            label6.Text = h.ToString();

            string caratteri = a.ToString() + s.ToString() + d.ToString() + f.ToString() + g.ToString() + h.ToString();

            

            for (int i = 0; i < caratteri.Length; i++) {
                if (caratteri[i] == '1') {
                    count[0] += 1;
                }
                else if (caratteri[i] == '2')
                {
                    count[1] += 1;
                }
                else if (caratteri[i] == '3')
                {
                    count[2] += 1;
                }
                else if (caratteri[i] == '4')
                {
                    count[3] += 1;
                }
                else if (caratteri[i] == '5')
                {
                    count[4] += 1;
                }
                else if (caratteri[i] == '6')
                {
                    count[5] += 1;
                }

            }

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            this.chart1.Series["Count"].Points.AddXY("1", count[0]);
            this.chart1.Series["Count"].Points.AddXY("2", count[1]);
            this.chart1.Series["Count"].Points.AddXY("3", count[2]);
            this.chart1.Series["Count"].Points.AddXY("4", count[3]);
            this.chart1.Series["Count"].Points.AddXY("5", count[4]);
            this.chart1.Series["Count"].Points.AddXY("6", count[5]);


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
