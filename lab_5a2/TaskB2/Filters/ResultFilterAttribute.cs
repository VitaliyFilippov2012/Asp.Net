using System.Web.Mvc;

namespace TaskB2.Filters
{
    public class ResultFilterAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<p>Result filter: {filterContext.HttpContext.Response}</p>");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Result filter executing</p>");
        }
    }
}