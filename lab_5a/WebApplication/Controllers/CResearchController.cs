using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("GET", "POST")]
        public ActionResult C01(string data)
        {
            RouteData r = this.RouteData;
            RouteValueDictionary rd = this.RouteData.Values;
            ViewBag.Rd = rd;

            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public ActionResult C02()
        {
            RouteData r = this.RouteData;
            RouteValueDictionary rd = this.RouteData.Values;
            StringBuilder response = new StringBuilder();
            foreach (string key in Request.Headers)
            {
                var value = Request.Headers[key];
                response.AppendLine(value + "<br />");
            }
            response.AppendLine("RawURI - " + Request.RawUrl + "<br />");
            response.AppendLine("Status - " + Response.Status+ "<br />");
            response.AppendLine("Body (form) - " + Request.Form + "<br />");
            Response.Write(response.ToString());
            ViewBag.Rd = rd;
            return View();
        }
    }
}