using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}