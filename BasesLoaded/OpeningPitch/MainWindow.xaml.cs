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
using System.Net;
using System.Net.Mail;

namespace OpeningPitch    
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Username_Input.Focus();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Window RegisterWindow = new RegisterWindow();
            RegisterWindow.Show();
        }

        private void Log_In_Click(object sender, RoutedEventArgs e)
        {
            if (Username_Input.Text.Equals("") || Password_Input.Password.Equals(""))
            {
                MessageBox.Show("You did not enter a valid Username and/or Password");
            }

            if (Username_Input.Text.Equals(true) && Password_Input.Password.Equals(true))
            {
                Window Dashboard = new Dashboard();
                Dashboard.Show();
            }
        }   

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NetworkCredential cred = new NetworkCredential("glen.a.hammer@stmartin.edu", "3turboturd3");
            MailMessage msg = new MailMessage();

            msg.To.Add("jeffrey.s.shaw4@gmail.com");
            msg.From = new MailAddress("glen.a.hammer@stmartin.edu");
            msg.Subject = "A Subject.";
            msg.Body = "Hello, this is my message.";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(msg);
        }              
    }
}
