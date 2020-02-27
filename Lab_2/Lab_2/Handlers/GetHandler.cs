using System.Text;
using System.Web;

namespace Lab_2.Handlers
{
    public class GetHandler : Handler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.Write(GetStringResultAfterRequestProc(context.Request));
        }

        public override string GetStringResultAfterRequestProc(HttpRequest request)
        {
            string parmA = request.QueryString["ParmA"];
            string parmB = request.QueryString["ParmB"];

            StringBuilder result = new StringBuilder("GET-Http-FVL:");
            if (parmA != null)
                result.Insert(result.Length, "ParmA = " + parmA);
            if (parmB != null)
                result.Insert(result.Length, "ParmB = " + parmB);

            return result.ToString();
        }
    }
}