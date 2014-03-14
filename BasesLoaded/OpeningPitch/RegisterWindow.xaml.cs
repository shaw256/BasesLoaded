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

        private delegate void UpdateProgressBarDelegate(
        System.Windows.DependencyProperty dp, Object value);
        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {

            //if (First_Name_Input.Text.Equals("") || Last_Name_Input.Text.Equals("") || E_Mail_Input.Text.Equals("") || Phone_Number_Input.Text.Equals(""))
            //{
            //    MessageBox.Show("Please fill all required fields.");
            //}
            //else
            //{
                try
                {
                    Prog_Bar.Minimum = 0;
                    Prog_Bar.Maximum = short.MaxValue;
                    Prog_Bar.Value = 0;

                    //Stores the value of the Prog_Bar
                    double value = 0;

                    //Create a new instance of the Prog_Bar Delegate that points
                    // to the Prog_Bar's SetValue method.
                    UpdateProgressBarDelegate updatePbDelegate =
                        new UpdateProgressBarDelegate(Prog_Bar.SetValue);

                    //Tight Loop: Loop until the ProgressBar.Value reaches the max
                    do
                    {
                        value += 20;
                        Dispatcher.Invoke(updatePbDelegate,
                                System.Windows.Threading.DispatcherPriority.Background,
                                new object[] { ProgressBar.ValueProperty, value });
                    }
                    while (Prog_Bar.Value != Prog_Bar.Maximum);

                    SmtpClient client = new SmtpClient("smtp.live.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("basesloadedapp@outlook.com", "!QAZ@WSX1qaz2wsx");

                    MailMessage msg = new MailMessage();
                    msg.To.Add("glen.a.hammer@gmail.com");
                    msg.From = new MailAddress("basesloadedapp@outlook.com");
                    msg.Subject = "Registration Successful";
                    msg.Body = "Congratulations!\nPlease follow the link below to verify your submission.";
                    client.Send(msg);
                    MessageBox.Show("Please check your E-Mail for a verification link.");

                    Window MainWindow = new MainWindow();
                    MainWindow.Show();
                    
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
    }
}
