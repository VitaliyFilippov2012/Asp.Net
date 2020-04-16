using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab01
{
    public class SumHttp : HttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            response.ContentType = "text/plain";

            if(int.TryParse(request.Params["Y"], out var ParamB) && int.TryParse(request.Params["X"], out var ParamA))
            {
                response.Write(ParamA + ParamB);
            }
        }
    }
}