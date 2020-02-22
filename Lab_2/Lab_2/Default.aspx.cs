using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnButtonClickGet(object sender, EventArgs e)
        {
            var rq = (HttpWebRequest) WebRequest.Create("localhost:55444/get.fvl");
            rq.Method = "GET";
            var rs = (HttpWebResponse) rq.GetResponse();
            var rdr = new StreamReader(rs.GetResponseStream());
            Response.Write(rdr.ReadToEnd());
        }

        protected void OnButtonClickOpt(object sender, EventArgs e)
        {

        }

        protected void OnButtonClickPost(object sender, EventArgs e)
        {

        }
    }
}