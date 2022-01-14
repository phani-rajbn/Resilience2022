using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day3
{
    enum Gender { Mr, Ms, Dr }
    //Entity classes as they represent real world entities. 
    class Employee
    {
        public int EmpId { get; set; } //properties are attributes of the class. They will have get and set. get will retrieve the data and set will assign the data. Properties are like fields but internally they work like functions.
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public Gender Gender { get; set; }
    }



    internal class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.EmpId = 123;
            emp.EmpName = "Phaniraj";
            emp.EmpAddress = "Bangalore";
            emp.EmpSalary = 60000;
            emp.Gender = Gender.Mr;

            Employee emp2 = new Employee { Gender = Gender.Ms, EmpId = 111, EmpSalary = 65000, EmpAddress = "Mysore", EmpName = "Sunanda Kumar" };   
            Console.WriteLine($"The Name is {emp.EmpName} from {emp.EmpAddress} earns a salary of {emp.EmpSalary:C} and {(emp.Gender == Gender.Mr ? "his" : "her")} Id is {emp.EmpId}");
            Console.WriteLine($"The Name is {emp2.EmpName} from {emp2.EmpAddress} earns a salary of { emp2.EmpSalary:C} and { (emp2.Gender == Gender.Mr ? "his" : "her")} Id is {emp2.EmpId}");
         }
    }
}
