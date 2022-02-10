using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult Index()
        {
            Student info    = new Student();
            return View(info);
        }

        [HttpPost]//Not required, but good to use
        public ActionResult AddStudent(Student student)
        {
            //Todo: make the student saved to the database using LINQ....
            return RedirectToAction("Index");
        }
    }
}