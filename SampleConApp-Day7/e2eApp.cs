using System;
using System.Collections.Generic;
using System.IO;

namespace SampleConApp_Day7
{
    interface IEmpDatabase
    {
        void AddNewEmployee(Employee employee); //C
        void UpdateEmployee(Employee employee); //U
        void DeleteEmployee(int id); //D
        List<Employee> GetAllEmployees(string name); //R
        Employee GetEmployee(int id);//R
    }

    class EmpDatabase : IEmpDatabase
    {
        HashSet<Employee> employeeSet = new HashSet<Employee>();//Initial size is 0...
        public void AddNewEmployee(Employee employee)
        {
            employeeSet.Add(employee);//No need to check for null or iterate thru the collection. 
        }

        public void DeleteEmployee(int id)
        {
            foreach (Employee emp  in employeeSet)
            {
                if(emp.EmpId == id)
                {
                    employeeSet.Remove(emp);
                    return;
                }
            }
            throw new Exception($"Employee by ID {id} does not exist to delete");
        }

        public List<Employee> GetAllEmployees(string name)
        {
            List<Employee> filter = new List<Employee>();//Create a temp list
            foreach (Employee emp in employeeSet)//iterate thro the set
            {
                if (emp.EmpName.Contains(name))//find the matching criteria
                {
                    filter.Add(emp);//add to temp list
                }
            }
            return filter;//return the temp list after the complete iterate of the set...
        }

        public Employee GetEmployee(int id)
        {
           foreach(Employee emp in employeeSet)
            {
                if (emp.EmpId == id) return emp;
            }
            throw new Exception($"Employee with ID {id} not found!!!!");
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException("Do It URself!!!");
        }
    }

    class e2eApp
    {
        static IEmpDatabase db = new EmpDatabase();
        static void Main(string[] args)
        {
            string filename = @"..\..\Menu.txt";
            if (!File.Exists(filename))
            {
                Console.WriteLine("Menu File is not correct");
                return;
            }
            string menu = File.ReadAllText(filename);
            bool processing = true;
            do
            {
                var choice = Input.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return true;
                default:
                    return false;
            }
        }
    }
}
//Exercise: The App has many gaps. It has bugs, please complete the program by calling the appropriate API in the processMenu and make the App run. 
