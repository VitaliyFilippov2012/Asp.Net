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

        protected async void OnButtonClickGet(object sender, EventArgs e)
        {
            var rq = (HttpWebRequest) WebRequest.Create("http://localhost:55444/get.fvl?ParmA=Kolya&ParmB=Actan");
            rq.Method = "GET";
            var response = (HttpWebResponse) await rq.GetResponseAsync();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            LabelResult.Text = reader.ReadToEnd();
        }

        protected void OnButtonClickPost(object sender, EventArgs e)
        {
            var rq = (HttpWebRequest)WebRequest.Create("http://localhost:55444/post.fvl");
            rq.Method = "POST";
            rq.MaximumResponseHeadersLength = 100;
            rq.ContentLength = 0; 
            byte[] parameters = System.Text.Encoding.UTF8.GetBytes("ParmA=Cat&ParmB=Dog");
            rq.ContentLength = parameters.Length;
            rq.ContentType = "application/x-www-form-urlencoded";
            var dataStream = rq.GetRequestStream();
            dataStream.Write(parameters, 0, parameters.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            LabelResult.Text = reader.ReadToEnd();
        }

        protected void OnButtonClickHead(object sender, EventArgs e)
        { 
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:55444/sum.math");
                request.Method = "HEAD";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                LabelResult.Text = reader.ReadToEnd();
            }
            catch (WebException exception)
            {
                LabelResult.Text = exception.Status.ToString();
                LabelResult.Text += "<br />" + exception.Message;
                LabelResult.Text += "<br />" + exception.TargetSite;
                LabelResult.Text += "<br />" + exception.Source;
            }
        }

        protected void OnButtonClickPut(object sender, EventArgs e)
        {
            var rq = (HttpWebRequest)WebRequest.Create("http://localhost:55444/sum.math");
            rq.Method = "PUT";
            rq.MaximumResponseHeadersLength = 100;
            rq.ContentLength = 0;
            WriteResponse((HttpWebResponse)rq.GetResponse());
        }

        private void WriteResponse(HttpWebResponse rs)
        {
            var rdr = new StreamReader(rs.GetResponseStream());
            Response.Write(rdr.ReadToEnd());
        }
    }
}