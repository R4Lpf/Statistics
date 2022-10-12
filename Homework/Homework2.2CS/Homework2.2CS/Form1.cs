using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2._2CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private static List<string[]> ReadAndParseData(string path, char separator) { 
        
            var parsedData = new List<string[]>();
            using (var sr = new StreamReader(path)) 
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split(separator);
                    parsedData.Add(row);
                }
                return parsedData;
            }
        
        }

        private void DrawDataGridView(List<string[]> parsedDAta) {
            int c = 15;
            dataGridView1.ColumnCount = c;
            for (int i = 0; i < c; i++) {
                var sb = new StringBuilder(parsedDAta[0][i]);
                sb.Replace("_", " ");
                sb.Replace("\"", "");
                dataGridView1.Columns[i].Name = sb.ToString();  
            }

            foreach (string[] row in parsedDAta) { 
                dataGridView1.Rows.Add(row);    
            }

            dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<string[]> parsedData = ReadAndParseData(@"C:\Users\aralm\Documents\GitHub\Statistics\Homework\Homework2.2CS\Homework2.2CS\Statistics_students_dataset_22_23 - Foglio1.csv", ',');
            DrawDataGridView(parsedData);
        }
    }
}
