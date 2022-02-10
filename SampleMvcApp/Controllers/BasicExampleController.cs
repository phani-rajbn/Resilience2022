using System;
using System.Web.Mvc;
using SampleMvcApp.Models;//namespace for UR Models

namespace SampleMvcApp.Controllers
{
    public class BasicExampleController : Controller
    {
        //Action in terms of MVC. 
        public string Greeting()
        {
            return "Welcome to ASP.NET MVC App";
        }
        public Employee Display()
        {
            var employee = new Employee{ EmpId = 123, EmpAddress = "Bangalore", EmpName = "Phaniraj", EmpSalary = 560000 };
            return employee;//Browser will convert the Employee object to String representation. 
        }

        public ViewResult EmpDetails()
        {
            //U get the data U want to display. 
            var employee = new Employee{ EmpId = 123, EmpAddress = "Bangalore", EmpName = "Phaniraj", EmpSalary = 560000 };
            return View(employee);//returning a View with Model(data) injected as arg
        }
    }
}