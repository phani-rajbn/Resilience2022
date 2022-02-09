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

        [HttpPost]
        public string AddEmployee(EmpTable input)
        {
            var context = new ResilienceDemoEntities();
            context.EmpTables.Add(input);
            context.SaveChanges();
            return "Employee added to the database";
        }
    }
}
