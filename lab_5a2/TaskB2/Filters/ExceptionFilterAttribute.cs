using System.Web.Mvc;

namespace TaskB2.Filters
{
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Write($"<p>EXCEPTION filter: {filterContext.Exception.Message}</p>");
        }
    }
}