using Assignment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment
{
    public class Data
    {
        public int id { get; set; }
        public string Description { get; set; }
        public double salary { get; set; }
        public Data(int id, string Description, double salary)
        {
            this.id = id;
            this.Description = Description;
            this.salary = salary;
        }
        public Data()
        {
        }
    }
    class Program
    {
        const string Filename = "MyData.txt";
        //static
        static List<Data> GetAllRecords()
        {
            List<Data> Ver = new List<Data>();
            string[] lines = File.ReadAllLines(Filename);
            foreach (string line in lines)
            {
                //Split the line
                var values = line.Split(',');
                var dt = new Data(int.Parse(values[0]), values[1], double.Parse(values[2]));
                Ver.Add(dt);
            }
            return Ver;
        }
        //static void create()
        //{
        // string[] lines = File.ReadAllLines(Filename);
        // foreach (string l in lines)
        // {
        // string[] sep = l.Split(',');
        // Data d = new Data();
        // }
        //}
        //create a a class called Data that has 3 properties ID, Description and Amount
        //create a constructor for this class that takes 3 args and sets the values to the properties.
        //Create an instance of this class in Main function and display the data.
        static void Main(string[] args)
        {
            IDataManager mgr = new DataManager();
            Data con = new Data(101, "Anitha", 20000);
            mgr.AddData(con);
            //saveData(con);
            //// Console.WriteLine($"the id is {con.id} and descption is {con.Description} and salary is {con.salary}");
            //var records = GetAllRecords();
            //foreach (var data in records)
            //{
            //    Console.WriteLine(data.Description);
            //}
        }
        private static void saveData(Data data)
        {
            string fileName = "MyData.txt";
            string value = $"{data.id},{data.Description},{data.salary}\n";
            File.AppendAllText(fileName, value);
        }
    }
}
