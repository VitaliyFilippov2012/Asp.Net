using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class MResearchController : Controller
    {
        [HttpGet]
        public ActionResult M01(int? id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult M02(int? id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult M03(int? id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult MXX(int? id)
        {
            return View();
        }
    }
}