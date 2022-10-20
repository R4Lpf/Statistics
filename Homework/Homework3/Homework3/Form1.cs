using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        

        private void DrawDataGridView(List<string[]> parsedDAta)
        {
            int c = 7;
            dataGridView1.ColumnCount = 7;
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
            List<string[]> parsedData = ReadAndParseData(@"C:\Users\aralm\Documents\GitHub\Statistics\Homework\Homework3\Homework3\wiresharkdata.csv", ',');
            DrawDataGridView(parsedData);

        }

        string[] source = new string[1840];
        string[] destination = new string[1840];
        List<string> stuff1 = new List<string>();
        List<string> stuff2 = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {


           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int i = 0;

            while (i < 32)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value != null)
                    {
                        source[i] = row.Cells["Source"].Value.ToString();
                        stuff1.Add(row.Cells["Source"].Value.ToString());
                        destination[i] = row.Cells["Destination"].Value.ToString();
                        stuff2.Add(row.Cells["Destination"].Value.ToString());
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

                var groups1 =
                        from s1 in stuff2
                        group s1 by s1 into g1
                        select new
                        {
                            Stuff = g1.Key,
                            Count = g1.Count()
                        };
                var dictionary1 = groups1.ToDictionary(g1 => g1.Stuff, g1 => g1.Count);


                foreach (var group in dictionary)
                {
                    this.chart1.Series["Sources"].Points.AddXY(group.Key, group.Value);

                }
                foreach (var group1 in dictionary1)
                {
                    this.chart2.Series["Destinations"].Points.AddXY(group1.Key, group1.Value);

                }
            }
        }
    }
}
