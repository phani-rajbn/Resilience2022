using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
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
    }
}