using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using PhoneDictionary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string _url = "https://localhost:44307/ContactsService.asmx";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void loadAllRecords()
        {
            var xml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap12:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" 
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                 xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                 <soap12:Body>
                     <GetDict xmlns=""http://microsoft.com/webservices/""/>
                </soap12:Body>
            </soap12:Envelope>";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(CallWebService(xml));
            var elements = xmlDoc.GetElementsByTagName("PhoneBook");

            List<PhoneBook> list = new List<PhoneBook>();
            for (var i = 0; i < elements.Count; i++)
            {
                var phone = new PhoneBook()
                {
                    Id = Guid.Parse(elements.Item(i).ChildNodes[0].InnerText),
                    Surname = elements.Item(i).ChildNodes[1].InnerText,
                    TelephoneNumber = elements.Item(i).ChildNodes[2].InnerText,
                };
                list.Add(phone);
            }

            dataGridView1.DataSource = list;
        }

        private void onSaveClick(object sender, EventArgs e)
        {
            if (button2.Text == "Save")
            {
                var c = CallWebService(GetSoapBody("AddDict", Guid.NewGuid().ToString()));
                loadAllRecords();
            }
            else
            {
                button2.Text = "Add New";
                textBox1.Text = "";
                button2.Text = "Save";
            }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            var c = CallWebService(GetSoapBody("UpdDict", textBox1.Text));
            loadAllRecords();
        }

        private void onDeleteClick(object sender, EventArgs e)
        {
            var c = CallWebService(GetSoapBody("DelDict", textBox1.Text));
            loadAllRecords();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadAllRecords();
        }

        private void onSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = this.dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0]?.Value?.ToString();
            textBox2.Text = row.Cells[1]?.Value?.ToString();
            textBox3.Text = row.Cells[2]?.Value?.ToString();
        }

        public string CallWebService(string xml)
        {
            var soapEnvelopeXml = CreateSoapEnvelope(xml);
            var webRequest = CreateWebRequest(_url);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            var asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            string soapResult;
            using (var webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (var rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }
            return soapResult;
        }

        private static HttpWebRequest CreateWebRequest(string url)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "application/soap+xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(String xml)
        {
            var soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (var stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        private string GetSoapBody(string action, string id)
        {
            return $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap12:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" 
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                 xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                 <soap12:Body>
                     <{action} xmlns=""http://microsoft.com/webservices/"">
                         <phoneBook>
                           <Id>{id}</Id>
                           <Surname>{textBox2.Text}</Surname>
                           <TelephoneNumber>{textBox3.Text}</TelephoneNumber>
                         </phoneBook>
                    </{action}>
               </soap12:Body>
            </soap12:Envelope>";
        }
    }
}
