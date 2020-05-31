using System;
using System.Web.Mvc;
using TaskB2.Filters;

namespace TaskB2.Controllers
{
    public class AResearchController : Controller
    {

        [Filters.ActionFilter]
        public ActionResult AA()
        {
            return Content("AA");
        }

        [ResultFilter]
        public ActionResult AK()
        {
            return Content("AK");
        }

        [ExceptionFilter]
        public ActionResult AE()
        {
            throw new Exception("My exception lyaaa");
        }
    }
}