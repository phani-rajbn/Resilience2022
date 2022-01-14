using System;
//namespace can span across multiple files. 
//C(Create)U(Update)R(Read) D(Delete)
namespace SampleConApp_Day3
{
    /// <summary>
    /// This class is created to manipulate the data of a class with functions. 
    /// </summary>
    class EmpManager
    {
        private Employee[] _employees; //private means that this field is not available outside the class. In this case, the _employees size is 10 and all are set to their default value null.

        //Constructor is a function that is invoked when U create an object of this class. 
        public EmpManager(int size)
        {
            _employees = new Employee[size];
            _employees[0] = new Employee { EmpAddress = "Bangalore", EmpId = 111, EmpName = "Phaniraj", EmpSalary = 60000, Gender = Gender.Mr };
            _employees[1] = new Employee { EmpAddress = "Mysore", EmpId = 112, EmpName = "Mahesh", EmpSalary = 63000, Gender = Gender.Mr };
            _employees[2] = new Employee { EmpAddress = "Bangalore", EmpId = 113, EmpName = "Supriya", EmpSalary = 70000, Gender = Gender.Mr };
            _employees[3] = new Employee { EmpAddress = "Tumkur", EmpId = 114, EmpName = "Ramkumar", EmpSalary = 40000, Gender = Gender.Mr };
            _employees[4] = new Employee { EmpAddress = "Bangalore", EmpId = 115, EmpName = "Pooja", EmpSalary = 90000, Gender = Gender.Ms };
        }

        /// <summary>
        /// Create new Employees into the System
        /// </summary>
        /// <param name="emp">Emp Details to add</param>
        public void AddEmployee(Employee emp)
        {
            //iterate thro the array, find the first occurance of the null location and insert the details passed as arguement into that location. exit the function.
            if (!empIdIsValid(emp.EmpId))
            {
                Console.WriteLine("EmpiD already exists");
                return; //we will not continue to add the record....
            }
                
            for (int i = 0; i < _employees.Length; i++)
            {
                if(_employees[i] == null)
                {
                    _employees[i] = new Employee { EmpAddress = emp.EmpAddress, Gender = emp.Gender, EmpSalary = emp.EmpSalary, EmpName = emp.EmpName, EmpId = emp.EmpId };
                    return;//exits the function and will no longer iterate. 
                }
            }
            Console.WriteLine("No vacancy in our organization");
        }
        
        /// <summary>
        /// Returns a valid Employee based on the ID of the Employee. If no Employee is found, it returns null
        /// </summary>
        /// <param name="id">ID of the Employee to find</param>
        /// <returns>Valid Employee object or null</returns>
        public Employee FindEmployee(int id)
        {
            //iterate thro the array. 
            foreach (Employee employee in _employees)
            {
                //check for the id and not null.
                if((employee != null) && (employee.EmpId == id))
                {
                    return employee;
                }
            }
            Console.WriteLine("No employee by this ID found in our System");
            return null;
        }

        /// <summary>
        /// Helper function used to find whether the ID is available or not.
        /// </summary>
        /// <param name="id">ID to Validate</param>
        /// <returns>True if Id is not available in the system</returns>
        private bool empIdIsValid(int id)
        {
            foreach (Employee emp in _employees)
            {
                if ((emp != null) && (emp.EmpId == id))
                    return false;
            }
            return true;
        }

    }

    class EmpManagerApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Size of Employees");
            int size = int.Parse(Console.ReadLine());
            EmpManager empManager = new EmpManager(size);
            empManager.AddEmployee(new Employee { EmpAddress ="Bangalore", EmpId =116, EmpName ="Akshay" , EmpSalary = 40000, Gender = Gender.Mr});

            Employee foundEmp = empManager.FindEmployee(114);
            if(foundEmp != null)
            {
                Console.WriteLine("the details are as follows:");
                Console.WriteLine($"Name: {foundEmp.EmpName}\nAddress:{foundEmp.EmpAddress}");
            }
        }
    }
}
