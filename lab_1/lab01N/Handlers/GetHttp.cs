using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab01
{
    public class GetHttp : HttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            response.ContentType = "text/plain";
            response.Write("GET-Http-FVL:ParamA = " + request.QueryString["ParamA"]
                           +", ParamB = " + request.QueryString["ParamB"]);
        }
    }
}