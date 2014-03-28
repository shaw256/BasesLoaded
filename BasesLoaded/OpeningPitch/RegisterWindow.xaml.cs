using System;
using System.Collections.Generic;
using System.Data;
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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public RegisterWindow()
        {
            InitializeComponent();
            First_Name_Input.Focus();
            this.State_Input.SelectedIndex = 1;
        }

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            if (First_Name_Input.Text.Equals("") || Last_Name_Input.Text.Equals("") || Email_Input.Text.Equals("") || Phone_Number_Input.Text.Equals("") || (Team_Captain.Equals(null) & Team_Player.Equals(null)))
            {
                MessageBox.Show("Please ensure all required fields are filled out.");
            }
            else if (New_Password_Input != Confirm_Password_Input)
            {
                MessageBox.Show("The Passwords do not match, Please try again.");
            }
            else
            {
                try
                {
                    var query = from stuff in db.Players
                                where stuff.Email == Email_Input.Text
                                select stuff;

                    if (query.Count() == 0)
                    {

                        Player user = new Player();
                        user.FirstName = First_Name_Input.Text;
                        user.LastName = Last_Name_Input.Text;
                        user.Email = Email_Input.Text;
                        user.PhoneNumber = Phone_Number_Input.Text;
                        user.Address = Address_Input.Text;
                        user.Address2 = Address2_Input.Text;
                        user.City = City_Input.Text;
                        user.State = State_Input.Text;
                        user.Zipcode = Zipcode_Input.Text;
                        user.Position = Position_Selection.Text;
                        user.AltPosition1 = Alt_Position_Selection.Text;
                        user.AltPosition2 = Alt_Position_Selection2.Text;
                        user.Gender = Gender_Selection.Text;
                        if (Team_Captain.IsChecked == true)
                        {
                            user.UserType = 1;
                            user.Approved = 1;
                        }

                        Security userSec = new Security();
                        userSec.Password = Confirm_Password_Input.ToString();
                        userSec.SID = user.PID;

                        db.Players.InsertOnSubmit(user);
                        db.SubmitChanges();
                    }

                    else
                    {
                        MessageBox.Show("Username already exists!");
                    }


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        

        //        try
        //        {
        //            SmtpClient client = new SmtpClient("smtp.live.com", 587);
        //            client.EnableSsl = true;
        //            client.Timeout = 10000;
        //            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            client.UseDefaultCredentials = false;
        //            client.Credentials = new NetworkCredential("basesloadedapp@outlook.com", "!QAZ@WSX1qaz2wsx");

        //            MailMessage msg = new MailMessage();
        //            msg.To.Add(Email_Input.Text);
        //            msg.From = new MailAddress("basesloadedapp@outlook.com");
        //            msg.Subject = "Registration Successful";
        //            msg.Body = "Congratulations!\nPlease follow the link below to verify your submission.";
        //            client.Send(msg);
        //            MessageBox.Show("Please check your E-Mail for a verification link.");
        //        }
        //        catch (Exception ex)
        //        {

        //            MessageBox.Show(ex.ToString());
        //        }
        //    }
        //}
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit Registration?\n\nAll data will be lost.",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                
            }
        }
        private void Minimize_Button(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to cancel your Registration?\n\nAll data will be lost.",
               "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                
            }
        }
    }
}

            

 

