using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab03.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            ViewBag.url = Request.RawUrl;
            ViewBag.method = Request.HttpMethod;
            return View();
        }
    }
}