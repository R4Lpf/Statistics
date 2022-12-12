using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_8
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Graphics g1, g2, g3;
        Bitmap b1, b2, b3;
        public (int, int) ConvertXY((double, double) point)
        {
            int Width = pictureBox1.Width;
            int Height = pictureBox1.Height;
            float MinX = 0;
            float MinY = 0;
            float MaxX = Width - 1;
            float MaxY = Height - 1;
            float x = ((float)(point.Item1 - MinX) / (float)(MaxX - MinX)) * Width;
            float y = Height - (((float)(point.Item2 - MinY) / (float)(MaxY - MinY)) * Height);

            return ((int)x, (int)y);
        }



        public Form1()
        {
            InitializeComponent();
            b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g1 = Graphics.FromImage(b1);
            int Width = pictureBox1.Width;
            int Height = pictureBox1.Height;
            float MinX = 0;
            float MinY = 0;
            float MaxX = Width - 1;
            float MaxY = Height - 1;
            g1.DrawRectangle(new Pen(Color.Black, 1), 0, 0, Width - 1, Height - 1);
            g1.DrawLine(new Pen(Color.Black, 1), 0, Height / 2 - 1, Width - 1, Height / 2 - 1);
            g1.DrawLine(new Pen(Color.Black, 1), Width / 2 - 1, 0, Width / 2 - 1, Height - 1);
            pictureBox1.Image = b1;

            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(b2);
            g2.DrawRectangle(new Pen(Color.Black, 1), 0, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
            pictureBox2.Image = b2;


            b3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g3 = Graphics.FromImage(b3);
            g3.DrawRectangle(new Pen(Color.Black, 1), 0, 0, pictureBox3.Width - 1, pictureBox3.Height - 1);
            pictureBox3.Image = b3;

            Console.WriteLine(MaxX/78);
            Console.WriteLine(MaxY/78);




        }

        public (int, int) GeneratePoint() {
            int Width = pictureBox1.Width;
            int Height = pictureBox1.Height;
            float MinX = 0;
            float MinY = 0;
            float MaxX = Width - 1;
            float MaxY = Height - 1;
            int Radius = r.Next(0, Width / 2 - 1);
            double Angle = r.NextDouble() * (360) * 0.0174533;
            double x = Radius * Math.Cos(Angle);
            double y = Radius * Math.Sin(Angle);



            return ConvertXY((x,y));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> Xarray = new List<int>(new int[78]) ; //{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            List<int> Yarray = new List<int>(new int[78]);//{ 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g1 = Graphics.FromImage(b1);
            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(b2);
            b3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            g3 = Graphics.FromImage(b3);

            int Width = pictureBox1.Width;
            int Height = pictureBox1.Height;
            
            g1.DrawRectangle(new Pen(Color.Black, 1), 0, 0, Width - 1, Height - 1);
            g2.DrawRectangle(new Pen(Color.Black, 1), 0, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
            g3.DrawRectangle(new Pen(Color.Black, 1), 0, 0, pictureBox3.Width - 1, pictureBox3.Height - 1);

            g1.DrawLine(new Pen(Color.Black, 1), 0, Height / 2 - 1, Width - 1, Height / 2 - 1);
            g1.DrawLine(new Pen(Color.Black, 1), Width / 2 - 1, 0, Width / 2 - 1, Height - 1);
            int increment = Width / 78;



            int Npoints = (int)numericUpDown1.Value;
            for (int i = 0; i < Npoints; i++) {
                (int, int) coordinates = GeneratePoint();
                int xSection = (coordinates.Item1 + Width / 2 - 1)/increment;
                int ySection = (coordinates.Item2 - Height / 2 - 1)/increment;
                Xarray[xSection]++;
                Yarray[ySection]++;
                g1.FillRectangle(Brushes.Black, coordinates.Item1 + Width / 2 - 1, coordinates.Item2 - Height / 2 - 1, 1,1);
                
            }

            for (int j = increment; j < Width - 1; j += increment)
            {
                g1.DrawLine(new Pen(Color.FromArgb(32, 0, 255, 0), 1), j, 0, j, Height-1);
                g1.DrawLine(new Pen(Color.FromArgb(32, 255, 0, 0), 1), 0, j, Width - 1, j);
            }
            int it = 0;
            for (int j = increment/2; j < Width - 1 ; j += increment)
            {

                int trueX = (Xarray[it] * pictureBox2.Height-1) / Xarray.Max();
                int trueY = (Yarray[it] * pictureBox2.Height-1) / Yarray.Max();
                g2.DrawLine(new Pen(Color.Green, 4), j, pictureBox2.Height-1, j, pictureBox2.Height - trueX);
                g3.DrawLine(new Pen(Color.Red, 4), j, pictureBox2.Height - 1, j, pictureBox2.Height - trueY);
                it++;
            }

            Console.WriteLine(string.Join(", ", Xarray));
            Console.WriteLine(string.Join(", ", Yarray));
            pictureBox1.Image = b1;

            pictureBox2.Image = b2;

            pictureBox3.Image = b3;


        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
