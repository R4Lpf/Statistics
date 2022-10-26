using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Homework4
{
    
    public partial class Form1 : Form
    {
        public Chart chart;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void A_Click(object sender, EventArgs e)
        {
            Global.IsRelative = false;
            Global.IsAbsolute = true;
            Global.IsNormalized = false;

            chart = new Chart(pictureBox1.Width, pictureBox1.Height, Global.TRIAL_NUMBER, Global.TRIAL_NUMBER);
            pictureBox1.Image = chart._Bitmap;
            foreach (DiceDistribution dice in Global.DiceCollection)
            {
                chart.InsertCollection(dice.AbsoluteFrequency, dice._Color);
            }

        }
        private void R_Click(object sender, EventArgs e)
        {
            Global.IsRelative = true;
            Global.IsAbsolute = false;
            Global.IsNormalized = false;

            chart = new Chart(pictureBox1.Width, pictureBox1.Height, Global.TRIAL_NUMBER, Global.PERCENTAGE_ACCURACY);
            pictureBox1.Image = chart._Bitmap;
            foreach (DiceDistribution dice in Global.DiceCollection)
            {
                chart.InsertCollection(dice.RelativeFrequency, dice._Color);
            }
        }

        private void N_Click(object sender, EventArgs e)
        {
            Global.IsRelative = false;
            Global.IsAbsolute = false;
            Global.IsNormalized = true;

            chart = new Chart(pictureBox1.Width, pictureBox1.Height, Global.TRIAL_NUMBER, Global.PERCENTAGE_ACCURACY);
            pictureBox1.Image = chart._Bitmap;
            foreach (DiceDistribution dice in Global.DiceCollection)
            {
                chart.InsertCollection(dice.NormalizedFrequency, dice._Color);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Global.DiceCollection = new List<DiceDistribution>();

            for (int i = 0; i < Global.COLLECTION_NUMBER; i++)
            {
                DiceDistribution dice = new DiceDistribution(Global.TRIAL_NUMBER, Global.PERCENTAGE_ACCURACY);
                Global.DiceCollection.Add(dice);
                System.Threading.Thread.Sleep(10);
                this.chart1.Series["Absolute Frequency"].Points.AddXY(i+1, (int) dice.AbsoluteFrequency[9999].Item2/100);
                this.chart2.Series["Relative Frequency"].Points.AddXY(i+1, (int) dice.RelativeFrequency[9999].Item2 / 100);
                this.chart3.Series["Normalized Frequency"].Points.AddXY(i+1, (int) dice.NormalizedFrequency[9999].Item2 / 100);
            }

            if (Global.IsAbsolute) A_Click(sender, e);
            else if (Global.IsRelative) R_Click(sender, e);
            else N_Click(sender, e);
        }

       
    }

    public class Global
    {
        //public static int PERCENTAGE_ACCURACY = 1000000;
        //public static int TRIAL_NUMBER = 10000;
        //public static int COLLECTION_NUMBER = 4;

        public static int PERCENTAGE_ACCURACY = 10000;
        public static int TRIAL_NUMBER = 10000;
        public static int COLLECTION_NUMBER = 10;
        public static List<DiceDistribution> DiceCollection = new List<DiceDistribution>();

        public static bool IsAbsolute = true;
        public static bool IsRelative = false;
        public static bool IsNormalized = false;
    }

    public class DiceDistribution
    {
        public Color _Color { get; set; }
        public int TrialNumber { get; set; }
        public int PercentageAccuracy { get; set; }
        public List<(int, int)> AbsoluteFrequency { get; set; }
        public List<(int, int)> RelativeFrequency { get; set; }
        public List<(int, int)> NormalizedFrequency { get; set; }
        public DiceDistribution(int trialNumber, int percentageAccuracy)
        {
            Random rand = new Random();

            _Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            TrialNumber = trialNumber;
            PercentageAccuracy = percentageAccuracy;
            AbsoluteFrequency = new List<(int, int)>();
            RelativeFrequency = new List<(int, int)>();
            NormalizedFrequency = new List<(int, int)>();

            int head = 0;
            Debug.Write($"\n");
            for (int i = 0; i < TrialNumber; i++)
            {
                if (rand.Next(0, 2) == 1)
                    head += 1;
                int percent = (int)((float)head / ((float)i + 1) * PercentageAccuracy);
                int normalized = (int)((float)head / ((float)Math.Sqrt(i + 1)) * (PercentageAccuracy / 100));



                
                AbsoluteFrequency.Add((i + 1, head));
                RelativeFrequency.Add((i + 1, percent));
                NormalizedFrequency.Add((i + 1, normalized));
            }
        }
    }

    public class Chart
    {
        public Bitmap _Bitmap { get; private set; }
        public Graphics _Graphics { get; private set; }
        private List<List<(int, int)>> Series { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int MinX { get; set; }
        public int MinY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Chart(int width, int height, int x, int y)
        {
            _Bitmap = new Bitmap(width, height);
            _Graphics = Graphics.FromImage(_Bitmap);
            Series = new List<List<(int, int)>>();

            Width = width;
            Height = height;

            MaxX = x;
            MaxY = y;
            MinX = 0;
            MinY = 0;
        }

        public void DrawLine(int x1, int y1, int x2, int y2, Pen pen)
        {
            _Graphics.DrawLine(pen, x1, y1, x2, y2);
        }
        public void DrawLine((int, int) p1, (int, int) p2, Pen pen)
        {
            _Graphics.DrawLine(pen, p1.Item1, p1.Item2, p2.Item1, p2.Item2);
        }

        public (int, int) ConvertCoordinates((int, int) point)
        {
            float x = ((float)(point.Item1 - MinX) / (float)(MaxX - MinX)) * Width;
            float y = Height - (((float)(point.Item2 - MinY) / (float)(MaxY - MinY)) * Height);

            return ((int)x, (int)y);
        }

        public void InsertCollection(List<(int, int)> collection, Color color)
        {
            Series.Add(collection);
            (int, int) buffer = collection[0];
            Pen pen = new Pen(color, 1);

            foreach ((int, int) item in collection.Skip(1))
            {
                DrawLine(ConvertCoordinates(buffer), ConvertCoordinates(item), pen);
                buffer = item;
            }
        }

        public void ComputeCandles(int x, int thickness, int maxLength, Color color)
        {
            Pen pen = new Pen(color, thickness);
            int startY = MaxY / 2;
            //if (Series.Count % 2 == 0) { startY += thickness + 3 + (((Series.Count / 2) - 1) * ((thickness * 2) + 3)); }
            //else { startY += (Series.Count / 2)  * ((Series.Count - 1) * ((thickness * 2) + 3)); }

            foreach (List<(int, int)> value in Series)
            {
                int c1 = value[x].Item1;
                int c2 = value[x].Item2;

                //Debug.WriteLine($"C1: {x} - C2: {c2}");
                //Debug.WriteLine($"C1: {c1} - C2: {c2}");
                //Debug.WriteLine($"-----------------");

                Debug.WriteLine($"X: {x} - X: {startY}");
                Debug.WriteLine($"X: {maxLength + x} - X: {startY}");

                DrawLine(ConvertCoordinates((x, startY)), ConvertCoordinates((maxLength + x, startY)), new Pen(Color.Red, thickness));
                startY -= ((thickness * 2) + 3);
            }
        }
    }
}
