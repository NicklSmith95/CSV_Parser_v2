using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CSVReader
{
    public partial class Form1 : Form
    {
		private List<MyData> GetData(string filePath)
        {
			List<MyData> results = new List<MyData>();

			if (File.Exists(filePath))
            {
				var rawData = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in rawData)
                {
                    var values = line.Split(",");
                    Array.Resize(ref values, 12);
                    var d = new MyData
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        CompanyName = values[2],
                        Address = values[3],
                        City = values[4],
                        County = values[5],
                        State = values[6],
                        Zip = values[7],
                        Phone1 = values[8],
                        Phone2 = values[9],
                        Email = values[10],
                        Web = values[11]

                    };
                    results.Add(d);
                }
            }
			return results;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            try
            {
                var myList = GetData(@"C:\Users\Donation\Desktop\Learn C#\CSV\Example_CSVs\grades.csv");
                if (myList.Any())
                {
                    dataGridView1.DataSource = myList;
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            
        }
    }
    public class MyData
	{
        public string FirstName { get; set; }
		public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
    }
}
