using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//In our example, the data is stored in a in-memory object.
namespace SampleMvcApp.Controllers
{
    public class AjaxDemoController : Controller
    {
        // GET: AjaxDemo
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Latest()
        {
            //get the articles from the App state.
            Queue<Article> articles = HttpContext.Application["Latest"] as Queue<Article>;
            var newList = articles.Reverse().ToList();
            //Reverse it to get the latest.
            return PartialView(newList);
        }

        public PartialViewResult NewArticle()
        {
            var model = new Article();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NewArticle(Article postedData)
        {
            //get the existing data from the App state...
            var articles = HttpContext.Application["Latest"] as Queue<Article>;//UNBOX...
            articles.Enqueue(postedData);//Adds to the bottom of the Queue.
            return RedirectToAction("Index");
        }

        public ActionResult AboutUs()
        {
            return View();
        }
    }
}