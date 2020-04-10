using System;
using System.Web;

namespace lab01
{
    public class GetPostHttpForm : HttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if (request.HttpMethod.Equals("GET"))
            {
                HandleGet(request, response);
            }
            else if (request.HttpMethod.Equals("POST"))
            {
                HandlePost(request, response);
            }
            else
            {
                response.StatusCode = 405;
                response.End();
            }
        }


        private void HandleGet(HttpRequest request, HttpResponse response)
        {
            response.TransmitFile("HtmlPage6.html");
        }

        private void HandlePost(HttpRequest request, HttpResponse response)
        {
            response.Write(int.Parse(request.Form.Get("X")) * int.Parse(request.Form.Get("Y")));
        }
    }
}