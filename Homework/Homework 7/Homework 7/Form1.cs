using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_7
{
    public partial class Form1 : Form
    {

        Random r = new Random();
        Graphics g1,g2;
        Bitmap b1,b2;
        public Form1()
        {
            InitializeComponent();
        }

        private int FromXRealToXVirtual(double X, double minX, double maxX, int Left, int W)
        {
            return (int)(Left + W * (X - minX) / (maxX - minX));
        }
        private int FromYRealToYVirtual(double Y, double minY, double maxY, int Top, int H)
        {
            return (int)(Top + H - H * (Y - minY) / (maxY - minY));
        }
        public int next(List<int> arr)
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

        private int PenSize(int t) 
        {
            return (int)((0.9 * t - 10) / (0.1 * t - 3.6));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g1 = Graphics.FromImage(b1);
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int tot = (int)numericUpDown2.Value;
            int lambda = (int)numericUpDown1.Value;
            double Y = 0;
            Pen PenTrajectory = new Pen(Color.Black, 1);
            List<Point> Points = new List<Point>();
            List<int> counterList = new List<int>();
            int counter = 0;
            bool prova = false;
            for (int X = 0; X <= tot; X++)
            {
                double val = r.NextDouble();

                if (val <= (float)((float)lambda / (float)tot))
                {
                    counterList.Add(counter);
                    counter = 0;
                    prova = true;
                    Y = Y + 1;
                }
                if (prova == false)
                {
                    counter += 1;
                }
                else
                {
                    counter = 0;
                    prova = false;
                }
                int xDevice = FromXRealToXVirtual(X, 0, tot, 0, pictureBox1.Width);
                int yDevice = FromYRealToYVirtual(Y, 0, tot, 0, pictureBox1.Height);
                Points.Add(new Point(xDevice, yDevice));
            }
            g1.DrawLines(PenTrajectory, Points.ToArray());
            pictureBox1.Image = b1;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(b2);
            g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int MyPen = PenSize(tot);
            
            Pen Pen = new Pen(Color.Black, MyPen);
            for (int i = 0; i < counterList.Count; i++)
            {
                int x = (pictureBox2.Width * i / counterList.Count)-MyPen;
                Point point1 = new Point(x, pictureBox2.Height);
                float dovefarloy = (float)counterList[i] / (float)next(counterList) * (float)pictureBox2.Height;
                Point point2 = new Point(x, pictureBox2.Height - (int)dovefarloy);
                g2.DrawLine(Pen, point1, point2);
            }
            pictureBox2.Image = b2;

        }
    }
}
