using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework6
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        int narrays = 0;
        int nrolls = 0;
        List<List<int>> rollMatrix = new List<List<int>>();



        public List<int> Gen(int n)
        {
            List<int> rollList = new List<int>();
            for (int i = 0; i < n; i++) {
                int a = r.Next(1, 7);
                rollList.Add(a);

            }
            return rollList;
        }

        double calculate_Variance(List<int> arr)
        {
            double squaredDifferences = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                double diff = (double)arr[i] - (double)((double)arr.Sum() / (double)(arr.Count));
                double squaredDiff = diff * diff;
                squaredDifferences += squaredDiff;
            }
            return (double)(squaredDifferences / (double)(arr.Count));
        }

        double calculate_Mean(List<int> arr)
        {

            return (double)(arr.Sum() / (double)(arr.Count)); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int narrays = (int)numericUpDown1.Value;
            int nrolls = (int)numericUpDown2.Value;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            rollMatrix = new List<List<int>>();


            double matrix_mean = 0;
            double matrix_variance = 0;

            for (int i = 0; i < narrays; i++) {
                List<int> a = Gen(nrolls);
                rollMatrix.Add(a);
                double list_mean = calculate_Mean(a);
                double list_variance = calculate_Variance(a);
                matrix_mean += list_mean;
                matrix_variance += list_variance;
                richTextBox1.AppendText("Mean of array " + (i + 1).ToString() + ": " + list_mean.ToString() + "\n");
                richTextBox2.AppendText("Variance of array " + (i + 1).ToString() + ": " + list_variance.ToString() + "\n");
                richTextBox3.AppendText("Array " + (i + 1).ToString() + ": [" + String.Join(", ", a.ToArray()) + "]\n");
            }
            textBox1.Text = ((double)matrix_mean / (double)narrays).ToString();
            textBox2.Text = ((double)matrix_variance / (double)narrays).ToString();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            narrays = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            nrolls = (int)numericUpDown2.Value;
        }
    }
}
