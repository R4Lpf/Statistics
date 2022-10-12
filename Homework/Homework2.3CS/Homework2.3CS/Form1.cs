using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Homework2._3CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static List<string[]> ReadAndParseData(string path, char separator)
        {

            var parsedData = new List<string[]>();
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split(separator);
                    parsedData.Add(row);
                }
                return parsedData;
            }

        }

        int[] altezze = new int[50];
        List<string> stuff1 = new List<string>();

        private void DrawDataGridView(List<string[]> parsedDAta)
        {
            int c = 4;
            dataGridView1.ColumnCount = 4;
            for (int i = 0; i < c; i++)
            {
                var sb = new StringBuilder(parsedDAta[0][i]);
                sb.Replace("_", " ");
                sb.Replace("\"", "");
                dataGridView1.Columns[i].Name = sb.ToString();
            }


            foreach (string[] row in parsedDAta)
            {
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.Rows.Remove(dataGridView1.Rows[0]);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> parsedData = ReadAndParseData(@"C:\Users\aralm\Documents\GitHub\Statistics\Homework\Homework2.2CS\Homework2.2CS\Statistics_students_dataset_22_23 - Foglio1.csv", ',');
            DrawDataGridView(parsedData);

        }

        private void button2_Click(object sender, EventArgs e)
        {


            int i = 0;

            while(i < 32) { 
                foreach (DataGridViewRow row in dataGridView1.Rows) {
                    if (row.Cells[3].Value != null)
                    {
                        altezze[i] = Int32.Parse(row.Cells[3].Value.ToString());
                        stuff1.Add(row.Cells[3].Value.ToString());
                        i++;
                    }
                }


                


                var groups =
                        from s in stuff1
                        group s by s into g
                        select new
                        {
                            Stuff = g.Key,
                            Count = g.Count()
                        };
                var dictionary = groups.ToDictionary(g => g.Stuff, g => g.Count);
                Debug.WriteLine("bruh");
                

                foreach (var group in dictionary) {
                    this.chart1.Series["Heights"].Points.AddXY(group.Key, group.Value);
                }
            }
        }
    }
}
