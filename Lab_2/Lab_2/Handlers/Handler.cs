using System.Web;

namespace Lab_2.Handlers
{
    public abstract class Handler : IHttpHandler
    {
        public virtual void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.Write(Message);
        }

        public bool IsReusable { get; }

        public string Message { get; set; } = "Handler";

        public virtual string GetStringResultAfterRequestProc(HttpRequest request)
        {
            return "";
        }
    }
}