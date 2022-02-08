using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database. 
        public ActionResult AllEmployees()
        {
            //Get the Model data
            var com = new DataComponent();
            var model = com.GetAllEmployees();  
            //Send it to the view
            return View(model);
        }

        public ActionResult OnEdit(string id)
        {
            int empId = Convert.ToInt32(id);
            var component = new DataComponent();
            try
            {
                var emp = component.FindEmployee(empId);
                return View(emp);   
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult OnEdit(Employee postedData)
        {
            var component = new DataComponent();
            try
            {
                component.UpdateEmployee(postedData);
                return RedirectToAction("AllEmployees");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult AddEmployee()
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee postedRec)
        {
            var com = new DataComponent();
            try
            {
                com.AddNewEmployee(postedRec);
                //throw new Exception("Testing Error!!!");
                return RedirectToAction("AllEmployees");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new Employee());
            }
        }
    }
}