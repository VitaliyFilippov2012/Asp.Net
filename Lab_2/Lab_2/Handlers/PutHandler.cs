using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Lab_2.Handlers
{
    public class PutHandler : Handler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.Write(GetStringResultAfterRequestProc(context.Request));
        }

        public override string GetStringResultAfterRequestProc(HttpRequest request)
        {
            string parmA = request["ParmA"];
            string parmB = request["ParmB"];

            StringBuilder result = new StringBuilder("PUT-Http-FVL:");

            if (parmA != null)
                result.Insert(result.Length, "ParmA = " + parmA);
            if (parmB != null)
                result.Insert(result.Length, "ParmB = " + parmB);

            return result.ToString();
        }
    }
}