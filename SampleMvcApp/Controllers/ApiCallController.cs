using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
namespace SampleMvcApp.Controllers
{
    public class ApiCallController : Controller
    {
        // GET: ApiCall
        public ActionResult Index()
        {
            using(var apiClient = new HttpClient())
            {
                var response = apiClient.GetAsync("http://localhost:56669/api/Employee").Result;
                object data = response.Content.ReadAsStringAsync().Result;
                return View(data);
            }
        }
    }
}