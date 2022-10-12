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
        /*
        private Task ProcessData(List<String> list, IProgress<ProgressReport> progress)
        {

            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() => {
                for (int j = 0; j < totalProcess; j++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(10);


                }
            });
        }*/
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        public int Gen() {
            return r.Next(1, 7);
        }

        int[] count = { 0, 0, 0, 0, 0, 0 };
        int c1 = 0; // A=0, B=0
        int c2 = 0; // A=0, B=1
        int c3 = 0; // A=1, B=0
        int c4 = 0; // A=1, B=1
        

        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            
            this.timer1.Start();


        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            this.progressBar1.Increment(1);

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


            int[] rand = { a, s, d, f, g, h };
            for (int i = 0; i < rand.Length; i++)
            {
                int a0 = 0;
                int b0 = 0;

                if (rand[i] % 2 == 0) {
                    a0 = 1;
                }
                if (rand[i] == 2 || rand[i] == 3 || rand[i] == 5) {
                    b0 = 1;
                }

                label8.Text = "A:" + a0.ToString();
                label9.Text = "B:" + b0.ToString();

                if (a0 == 0 & b0 == 0) { c1 += 1; }
                else if (a0 == 0 & b0 == 1) { c2 += 1; }
                else if (a0 == 1 & b0 == 0) { c3 += 1; }
                else if (a0 == 1 & b0 == 1) { c4 += 1; }


            }

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }

            this.chart2.Series["Series1"].Points.AddXY("0", c1);
            this.chart2.Series["Series1"].Points.AddXY("1", c2);
            this.chart2.Series["Series1"].Points.AddXY("2", c3);
            this.chart2.Series["Series1"].Points.AddXY("3", c4);

            if (progressBar1.Value >= progressBar1.Maximum) {
                timer1.Stop();
            }
        }

    }
}
