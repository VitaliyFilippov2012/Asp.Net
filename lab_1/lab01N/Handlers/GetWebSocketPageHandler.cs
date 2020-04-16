using System;
using System.Web;

namespace lab01
{
    public class GetWebSocketPageHandler : HttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var response = context.Response;

            response.TransmitFile("WebSocketPage.html");
        }
    }
}