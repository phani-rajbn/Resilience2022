using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day11
{
    class Employee
    {
        public int EmpSalary { get; set; }
        public string EmpAddress { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
    }

    internal class LinqForObjects
    {
        //Helper function to convert a line data into an Employee object...
        static Employee createEmployee(string line)
        {
            var words = line.Split(',');
            var emp = new Employee();
            emp.EmpId = int.Parse(words[0]);
            emp.EmpName = words[1];
            emp.EmpAddress = words[2];
            emp.EmpSalary = int.Parse(words[3]);
            return emp;
        }

        const string fileName = "../../SampleData.csv";
        static List<Employee> employees = new List<Employee>();
        static void fillRecords()
        {
            if (!File.Exists(fileName)) return;
            var contents = File.ReadAllLines(fileName);
            foreach (var line in contents)
            {
                var emp = createEmployee(line);
                employees.Add(emp);
            }
        }

        static LinqForObjects()
        {
            fillRecords();
        }

        static void Main(string[] args)
        {
            //get only names
            var records = from rec in employees
                          where rec.EmpAddress == "Mysore"
                          orderby rec.EmpName descending
                          select new { rec.EmpName, rec.EmpAddress };
            foreach (var rec in records)
            {
                Console.WriteLine($"{rec.EmpName} from {rec.EmpAddress}");
            }
        }
    }
}
