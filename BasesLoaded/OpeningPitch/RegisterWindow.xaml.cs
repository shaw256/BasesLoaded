﻿using System;
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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public RegisterWindow()
        {
            InitializeComponent();
            First_Name_Input.Focus();
        }

        LINQtoSQLDataContext LINQ = new LINQtoSQLDataContext();

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (First_Name_Input.Text.Equals("") || Last_Name_Input.Text.Equals("") || Email_Input.Text.Equals("") || Phone_Number_Input.Text.Equals("") || Team_Selection.Equals(null))
            //{
            //    MessageBox.Show("Please ensure all required fields are filled out.");
            //}
            //else if (New_Password_Input != Confirm_Password_Input)
            //{
            //    MessageBox.Show("The Passwords do not match, Please try again.");
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
                    MessageBox.Show("Please check your E-Mail for a verification link.");
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
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                
            }
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

            

 
