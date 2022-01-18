using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day4
{
    interface IAdmin
    {
        void Create();
    }

    interface IEmployee
    {
        void Create();
    }
    //When U have naming conflict in the methods of 2 interfaces, U can give the implementation using the interfaceName.methodName.
    class EmployeeAdmin : IAdmin, IEmployee
    {
        //Explit interface Implementation.
        void IEmployee.Create()
        {
            Console.WriteLine("Employee is created");
        }
        void IAdmin.Create()
        {
            Console.WriteLine("Admin is created");
        }
        public void Create()
        {
            Console.WriteLine("Employee with Admin rights is created");
        }


    }
    internal class MultipleInterfaceDemo
    {
        static void Main(string[] args)
        {
            IAdmin admin = new EmployeeAdmin();
            admin.Create();

            IEmployee employee = new EmployeeAdmin();
            employee.Create();

            EmployeeAdmin employeeAdmin = new EmployeeAdmin();
            employeeAdmin.Create();
        }
    }
}
