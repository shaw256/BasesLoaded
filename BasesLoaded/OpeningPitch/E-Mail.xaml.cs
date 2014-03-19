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
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace OpeningPitch
{
    /// <summary>
    /// Interaction logic for E_Mail.xaml
    /// </summary>
    public partial class E_Mail : Window
    {
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public E_Mail()
        {
            InitializeComponent();
        }

        private void Email_To(object sender, TextCompositionEventArgs e)
        {

        }

        private void Subject_To(object sender, TextCompositionEventArgs e)
        {

        }

        private void Message_Input(object sender, TextCompositionEventArgs e)
        {

        }

        private void Send_Button(object sender, RoutedEventArgs e)
        {
            //NetworkCredential cred = new NetworkCredential("glen.a.hammer@stmartin.edu", "3turboturd3");
            //MailMessage msg = new MailMessage();

            //msg.To.Add("jeffrey.s.shaw4@gmail.com");
            //msg.From = new MailAddress("glen.a.hammer@stmartin.edu");
            //msg.Subject = "A Subject.";
            //msg.Body = "Hello, this is my message.";

            //SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            //client.Credentials = cred;
            //client.EnableSsl = true;
            //client.Send(msg);
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
