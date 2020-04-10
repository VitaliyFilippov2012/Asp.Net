using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab01
{
    public class GetPostHttp : HttpHandler
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
            response.TransmitFile("HtmlPage5.html");
        }

        private void HandlePost(HttpRequest request, HttpResponse response)
        {
            response.Write(int.Parse(request.QueryString["X"]) * int.Parse(request.QueryString["Y"]));
        }
    }
}