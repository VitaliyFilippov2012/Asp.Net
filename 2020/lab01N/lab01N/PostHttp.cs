using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab01;

namespace lab01
{
    public class PostHttp : HttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            response.ContentType = "text/plain";
            response.Write("POST-Http-FVL:ParamA = " + request.QueryString["ParamA"] 
                                                     + "ParamB = " + request.QueryString["ParamB"]);
        }
    }
}