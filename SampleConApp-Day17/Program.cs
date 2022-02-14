using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataLib;//Use the namespace of the dll
namespace SampleConApp_Day17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //U can now consume the dll and its classes as if it is in ur project
            string name = Input.GetAnswer("Enter the Name");
            string address = Input.GetAnswer("Enter the Address");
            double salary = Input.GetDouble("Enter the Salary");
            DateTime dt = Input.GetDate("Enter the date of birth");
            int age =  DateTime.Now.Year-dt.Year  ;
            Console.WriteLine($"Mr.{name} is from {address} and earns a salary of {salary:C} and is aged {age}");
        }
    }
}
