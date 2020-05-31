using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi_.Controllers
{
    public class ViewController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("MainView");
        }
    }
}