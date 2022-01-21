using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp_Day8
{
    internal interface IEmpDatabase
    {
        void AddNewEmployee(Employee employee); //C
        void UpdateEmployee(Employee employee); //U
        void DeleteEmployee(int id); //D
        List<Employee> GetAllEmployees(string name); //R
        Employee GetEmployee(int id);//R
    }
}
