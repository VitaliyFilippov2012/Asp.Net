using System.Text;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("GET", "POST")]
        public ActionResult C01()
        {
            ViewBag.Rd = this.RouteData.Values;

            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public ActionResult C02()
        {
            var rd = this.RouteData.Values;
            var response = new StringBuilder();
            foreach (string key in Request.Headers)
            {
                var value = Request.Headers[key];
                response.AppendLine(value + "<br />");
            }
            response.AppendLine("RawURI - " + Request.RawUrl + "<br />");
            response.AppendLine("Status - " + Response.Status + "<br />");
            response.AppendLine("Body (form) - " + Request.Form + "<br />");
            Response.Write(response.ToString());
            ViewBag.Rd = rd;
            return View();
        }
    }
}