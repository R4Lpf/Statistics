using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_8._2
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Bitmap b1;
        Graphics g1;
        public Form1()
        {
            InitializeComponent();
        }

        public double next(List<double> arr)
        {
            if (arr.Max() == 0)
            {
                return arr.Count;
            }
            else
            {
                return arr.Max();
            }
        }

        private void Draw(double Dmin, double Dmax, string Dval) {
            b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g1 = Graphics.FromImage(b1);
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            double minValue = 0;
            double maxValue = 0;
            int nCols = (int)numericUpDown2.Value; ;
            int n = (int)numericUpDown1.Value;
            List<double> Values = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double x = 0;
                double y = 0;
                double value = 0;
                double val = -8;

                while (val < 0 || val > 1)
                {
                    x = (r.NextDouble() * 2) - 1;
                    y = (r.NextDouble() * 2) - 1;
                    val = (x * x) + (y * y);
                }

                x = x * Math.Sqrt(-2 * Math.Log(val) / val);
                y = y * Math.Sqrt(-2 * Math.Log(val) / val);

                minValue = Dmin;
                maxValue = Dmax;
                switch (Dval) {
                    case "x": value = x; break;
                    case "x*x": value = x * x; break;
                    case "x / (y * y)": value = x / (y * y); break;
                    case "(x * x) / (y * y)": value = (x * x) / (y * y); break;
                    case "x / y": value = x / y; break;
                }

                Values.Add(value);
            }
            double delta = maxValue - minValue;
            double interval = delta / nCols;
            double da = minValue;
            double a = minValue + interval;
            int l = 0;
            List<double> Cols = new List<double>();
            for (int i = 0; i < nCols; i++)
            {
                foreach (double v in Values)
                {
                    if (v > da & v < a)
                    {
                        l++;
                    }
                }
                Cols.Add(l);
                l = 0;
                da = a;
                a = a + interval;
            }
            for (int i = 0; i < Cols.Count; i++)
            {
                int positionX = pictureBox1.Width * (i) / Cols.Count + 1;
                Point point1 = new Point(positionX, pictureBox1.Height);
                float positionY = (float)Cols[i] / (float)next(Cols) * (float)pictureBox1.Height;
                Point point2 = new Point(positionX, pictureBox1.Height - (int)positionY);
                g1.DrawLine(new Pen(Color.Green, 1), point1, point2);
            }
            pictureBox1.Image = b1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw(-4, 4, "x");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw(0, 3, "x*x");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Draw(-9, 9, "x / (y * y)");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Draw(0, 3, "(x * x) / (y * y)");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Draw(-9, 9, "x / y");
        }
    }
}
