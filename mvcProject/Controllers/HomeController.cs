using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using mvcProject.FilterCs;

namespace mvcProject.Controllers
{
    [Session]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            test1Entities test = new test1Entities();
            List<ces> resultList=test.ces.ToList(); 
            ViewBag.jsonStr = JsonConvert.SerializeObject(resultList);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}