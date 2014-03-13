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
using System.Net.Mime;

namespace OpeningPitch
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    

    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void First_Name(object sender, TextChangedEventArgs e)
        {

        }

        private void Last_Name(object sender, TextChangedEventArgs e)
        {

        }

        private void E_Mail(object sender, TextChangedEventArgs e)
        {

        }

        private void D_O_B(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Phone_Number(object sender, TextChangedEventArgs e)
        {

        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("glen.a.hammer@gmail.com", "3turboturd3!@#");

                MailMessage msg = new MailMessage();
                msg.To.Add("glen.a.hammer@gmail.com");
                msg.From = new MailAddress("glen.a.hammer@gmail.com");
                msg.Subject = "A Subject.";
                msg.Body = "Congratulations!\nPlease follow the link below to verify your submission.";
                client.Send(msg);
                MessageBox.Show("Please check your E-Mail for a verification link.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit Registration?\n\nAll data will be lost.",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Application curApp = Application.Current;
                curApp.Shutdown();
            }
            else if (result == MessageBoxResult.Cancel)
            {

            }
        }
    }
}
