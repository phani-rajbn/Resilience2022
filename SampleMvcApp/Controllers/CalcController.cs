using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string firstValue, string secondValue, string option)
        {
            var v1 = double.Parse(firstValue);
            var v2 = double.Parse(secondValue);
            var res = operate(v1, v2, option);
            TempData["result"] = res;
            return View();
        }
        //public ActionResult Index(FormCollection form)
        //{
        //    var firstValue = double.Parse(form["firstValue"]);
        //    var secondValue = double.Parse(form["secondValue"]);
        //    var option = form["option"];
        //    var res = operate(firstValue, secondValue, option);
        //    ViewData["result"] = res;
        //    return View();
        //}

        private double operate(double v1, double v2, string option)
        {
            double res = 0.0;
            switch (option)
            {
                case "Add": res = v1 + v2; break;
                case "Subtract": res = v1 - v2; break;
                case "Multiply": res = v1 * v2; break;
                case "Divide": res = v1 / v2; break;
            }
            return res;
        }
    }
}