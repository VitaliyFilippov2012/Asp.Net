using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://172.16.193.234:44106/Lab1A/sum?X=" + FirstNum.Text + "&Y=" + SecondNum.Text);

            request.Method = "POST";
            request.ContentLength = 0;

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                Result.Text = stream.ReadToEnd();
            }
        }
    }
}
