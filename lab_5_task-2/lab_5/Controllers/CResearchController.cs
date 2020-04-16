using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_5.Controllers
{
    public class CResearchController : Controller
    {
        // GET - POST: CResearch/ || CResearch/C01
        [HttpGet]
        [HttpPost]
        public ActionResult C01()
        {
            return View();
        }

        // GET - POST: CResearch/C02
        [HttpGet]
        [HttpPost]
        public ActionResult C02()
        {
            return View();
        }
    }
}
