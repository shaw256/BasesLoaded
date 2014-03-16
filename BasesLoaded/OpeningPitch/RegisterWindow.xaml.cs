using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
using System.Windows.Shapes;



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
            First_Name_Input.Focus();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (First_Name_Input.Text.Equals("") || Last_Name_Input.Text.Equals("") || E_Mail_Input.Text.Equals("") || Phone_Number_Input.Text.Equals(""))
            //{
            //    MessageBox.Show("You did not enter a valid Username and/or Password");
            //}
            //else
            //{
            try
            {

                SmtpClient client = new SmtpClient("smtp.live.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("basesloadedapp@outlook.com", "!QAZ@WSX1qaz2wsx");

                MailMessage msg = new MailMessage();
                msg.To.Add(Email_Input.Text);
                msg.From = new MailAddress("basesloadedapp@outlook.com");
                msg.Subject = "Registration Successful";
                msg.Body = "Congratulations!\nPlease follow the link below to verify your submission.";
                client.Send(msg);
                MessageBox.Show( "Please check your E-Mail for a verification link.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            //}
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

        private void Alt_Position_Selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to cancel your Registration?\n\nAll data will be lost.",
               "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
            }
            else if (result == MessageBoxResult.Cancel)
            {

            }
        }

               
    }
}

            //if (Email_Input.Text.Length <= 0)
            //{
            //    MessageBox.Show("Enter an email.");
            //    Email_Input.Focus();
            //}
                 
            //else if (!Regex.IsMatch(Email_Input.Text, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            //+ @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            //+ @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$"))
            //{
            //    MessageBox.Show("Enter a Valid Email.");
            //    Email_Input.Clear();
            //    Email_Input.Focus();
            //}
    

 

