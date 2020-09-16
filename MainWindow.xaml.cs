using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MoodleSpam
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i <= int.Parse(textboxAmount.Text); i++)
            {
                var request = (HttpWebRequest)WebRequest.Create(textboxURL.Text + "/lib/ajax/service.php?sesskey=" + textboxSesskey.Text + "&info=core_message_send_messages_to_conversation");
                request.ContentType = "application/json";
                request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:69.0) Gecko/20100101 Firefox/69.0";
                request.Method = "POST";

                //Cookie Container
                //request.CookieContainer = new CookieContainer();
                //request.CookieContainer.Add("Test", "Test2");
                request.Headers.Add("Cookie: MoodleSession=" + textboxMoodleSession.Text);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "[{\"index\":0,\"methodname\":\"core_message_send_messages_to_conversation\",\"args\":{\"conversationid\":" + textboxConvID.Text + ",\"messages\":[{\"text\":\"" + textboxMessage.Text + "\"}]}}]";
                    streamWriter.Write(json);
                }

                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    textBlockResponse.Text = "Response: " + result;
                }
            }
        }

        private void OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void sessKeyText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9A-Za-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void moodleSessionText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9a-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
