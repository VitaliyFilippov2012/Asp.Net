using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Lab_2.Handlers
{
    public class PostMathHandler : Handler
    {
        public override void ProcessRequest(HttpContext context)
        { 
            context.Response.Write(GetStringResultAfterRequestProc(context.Request));
        }

        public override string GetStringResultAfterRequestProc(HttpRequest request)
        {
            float.TryParse(request["x"], out var a);
            float.TryParse(request["y"], out var b);

            return (a + b).ToString(CultureInfo.InvariantCulture);
        }
    }
}