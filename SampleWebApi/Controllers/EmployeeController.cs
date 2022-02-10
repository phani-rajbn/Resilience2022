using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public List<EmpTable> GetAllEmployees()
        {
            var context = new ResilienceDemoEntities();
            var empRecords = context.EmpTables.ToList();
            return empRecords;
        }

        [HttpGet]
        public EmpTable FindEmployee(int id)
        {
            var context = new ResilienceDemoEntities();
            var selected = context.EmpTables.FirstOrDefault((e)=>e.EmpId == id);
            return selected;
        }

        [HttpPost]
        public string AddEmployee(EmpTable input)
        {
            var context = new ResilienceDemoEntities();
            context.EmpTables.Add(input);
            context.SaveChanges();
            return "Employee added to the database";
        }
        [HttpDelete]
        public string DeleteEmployee(int id)
        {
            var context = new ResilienceDemoEntities();
            var selected = context.EmpTables.FirstOrDefault((e)=>e.EmpId==id);
            if (selected != null)
            {
                context.EmpTables.Remove(selected);
                context.SaveChanges();
                return $"Employee with id {id} deleted Successfully";
            }
            else
                return "No Employee found to delete";
        }
        [HttpPut]
        public string UpdateEmployee(EmpTable emp)
        {
            var context = new ResilienceDemoEntities();//create the context
            var selected = context.EmpTables.FirstOrDefault((e)=>e.EmpId==emp.EmpId);//get the matching rec
            if(selected == null)
            {
                return "Employee not found to update";
            }
            selected.DeptID = emp.DeptID;//set the values to the found record.
            selected.EmpSalary = emp.EmpSalary;
            selected.EmpAddress = emp.EmpAddress;
            selected.EmpName = emp.EmpName;
            context.SaveChanges();
            return "Employee updated to the database";
        }
    }
}
