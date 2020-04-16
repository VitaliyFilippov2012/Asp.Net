using System.Web;
using System.Web.Mvc;

namespace lab01
{
    public class HttpHandler : Controller, IHttpHandler
    { 
        public bool IsReusable => false;

        public virtual void ProcessRequest(HttpContext context)
        {
            var response = context.Response;

            response.ContentType = "text/plain";
            response.Write("Default");
        }
    }
}