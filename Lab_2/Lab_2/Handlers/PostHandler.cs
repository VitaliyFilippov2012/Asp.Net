using System.Text;
using System.Web;

namespace Lab_2.Handlers
{
    public class PostHandler : Handler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.Write(GetStringResultAfterRequestProc(context.Request));
        }

        public override string GetStringResultAfterRequestProc(HttpRequest request)
        {
            string parmA = request["ParmA"];
            string parmB = request["ParmB"];

            StringBuilder result = new StringBuilder("POST-Http-FVL:");

            if (parmA != null)
                result.Insert(result.Length, "ParmA = " + parmA);
            if (parmB != null)
                result.Insert(result.Length, "ParmB = " + parmB);

            return result.ToString();
        }
    }
}