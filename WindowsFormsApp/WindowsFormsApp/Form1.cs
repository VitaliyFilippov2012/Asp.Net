using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendRequestButton_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:55444/post.fvl");
            request.Method = "POST";

            byte[] parameters = System.Text.Encoding.UTF8.GetBytes("ParmA=First&ParmB=Second");
            request.ContentLength = parameters.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            var dataStream = request.GetRequestStream();
            dataStream.Write(parameters, 0, parameters.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            ResultTextBox.Text = reader.ReadToEnd();
        }
    }
}