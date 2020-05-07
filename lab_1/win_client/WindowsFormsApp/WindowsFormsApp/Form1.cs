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
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:23331/sum.fvl");
            request.Method = "POST";

            byte[] parameters = System.Text.Encoding.UTF8.GetBytes($"Y={textBox1.Text}&X={textBox2.Text}");
            request.ContentLength = parameters.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            var dataStream = request.GetRequestStream();
            dataStream.Write(parameters, 0, parameters.Length);
            dataStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            ResultTextBox.Text = reader.ReadToEnd();
        }
    }
}