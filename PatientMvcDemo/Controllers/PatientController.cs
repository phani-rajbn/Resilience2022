using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleDataLib.Entities;
using SampleDataLib.DataLayer;
namespace PatientMvcDemo.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            var com = PatientFactory.CreateComponent();
            var data = com.GetAllPatients();    
            return View(data);
        }

        public ActionResult AddNew()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult AddNew(Patient posted)
        {
            var com = PatientFactory.CreateComponent();
            posted.BillDate = DateTime.Now;
            com.AddNewPatient(posted);
            return RedirectToAction("Index");
        }
    }
}