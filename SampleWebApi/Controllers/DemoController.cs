using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;//Namespace for Web API.

namespace SampleWebApi.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        public string[] fruits()
        {
            return new string[] { "Apples", "Mangoes", "Bananas", "Oranges", "PineApples", "Kiwis" };
        }

        [HttpGet]
        [Route("Cars")]//To define a URL Pattern if U have multiple gets. 
        public string[] Cars()
        {
            return new string[] { "Santro", "Honda WRV", "Kia- Sonnet", "Maruti Zen" };
        }
    }
}
