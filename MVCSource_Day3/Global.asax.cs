using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleMvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()//Event when the App starts for the very first time..
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Context.Application["Latest"] = new Queue<Article>();
        }
    }
}
