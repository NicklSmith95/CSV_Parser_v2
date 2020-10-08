//Importing System Classes
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//Namespace for keeping "Names" Seperate (helps with similarly named classes)
namespace CSVReader
{//Form Class (Form1.cs)
    public partial class Form1 : Form
    {//Method to return MyData List
		private List<MyData> GetData(string filePath)
        {//Makes lists, stores in variable called results
			List<MyData> results = new List<MyData>();
            //verifiys if the file in the filePath is valid
			if (File.Exists(filePath))
            {//Takes the data in the filepath and reads it but skips the 1st row
				var rawData = File.ReadAllLines(filePath).Skip(1);
                // Loop to loop through the lines of data in the rawData variable
                foreach (var line in rawData)
                {//Splits the line data into values on the deliminator ","
                    var values = line.Split(",");
                    //Resizes the Array so that you wont get an Index Out of Range error if csv is shorter than 12 colums
                    Array.Resize(ref values, 12);
                    // creates a new MyData and stores the values in the variable d
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
                    //adds d to the results
                    results.Add(d);
                }
            }
            //returns results
			return results;
        }
        //initializes the form
        public Form1()
        {
            InitializeComponent();
        }
        //loads form 1
        private void Form1_Load(object sender, EventArgs e)
        {   //tries to grab the csv file and stores it in the varible myList
            try
            {
                var myList = GetData(@"C:\Users\Donation\Desktop\Learn C#\CSV\Example_CSVs\us-500.csv");
                //if myList is valid, displays onto the datagrid
                if (myList.Any())
                {
                    dataGridView1.DataSource = myList;
                }
                
            }
            //catches any exceptions
            catch (Exception er)
            {
                //pops up message box to display caught error message
                MessageBox.Show(er.Message);
            }
            
        }
    }
    //Class defining the structure of MyData
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

