using System.Web.Mvc;

namespace TaskB2.Filters
{
    public class ActionFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Action filter</p>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Action filter executing</p>");
        }
    }
}