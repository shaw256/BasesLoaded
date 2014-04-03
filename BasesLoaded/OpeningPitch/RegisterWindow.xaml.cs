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
        private int _noOfErrorsOnScreen = 0;
        private RegisterValidation _applicant = new RegisterValidation();
        LINQtoSQLDataContext db = new LINQtoSQLDataContext();

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
       
        
        public RegisterWindow()
        {
            InitializeComponent();
            First_Name_Input.Focus();
            this.State_Input.SelectedIndex = 1;
            Register_Window.DataContext = _applicant;
            PopulateTeamComboBox();
            TeamList.Visibility = Visibility.Hidden;
            CustomTeam.Visibility = Visibility.Hidden;
            CustomTeamLabel.Visibility = Visibility.Hidden;
            TeamListLabel.Visibility = Visibility.Hidden;
        }

        public void PopulateTeamComboBox()
        {
            var currentTeamQuery = (from teams in db.Teams
                            select new { teams.TeamName }).ToList();
            
            
            this.TeamList.ItemsSource = currentTeamQuery;
            this.TeamList.DisplayMemberPath = "TeamName";
            this.TeamList.SelectedValuePath = "TeamName";
            
        }


        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        
        private void Applicant_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void Applicant_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            RegisterValidation _applicant = Register_Window.DataContext as RegisterValidation;

            //if (First_Name_Input.Text.Equals("") || Last_Name_Input.Text.Equals("") || Email_Input.Text.Equals("") || Phone_Number_Input.Text.Equals(""))
            //{
            //    MessageBox.Show("Please ensure all required fields are filled out.");
            //}
            //else if (New_Password_Input != Confirm_Password_Input)
            //{
            //    MessageBox.Show("The Passwords do not match, Please try again.");
            //}

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
                    user.Password = Confirm_Password_Input.Password;
                    
                    
                    
                    
                    if (Team_Captain.IsChecked == true)
                    {
                        user.UserType = 1;
                        user.Approved = 1;
                        globals.user.UserType = user.UserType;
                    }

                    var teamquery = from teams in db.Teams
                                    where teams.TeamName == "TestTeam"
                                    select teams.TID;

                    foreach (var team in teamquery)
                    {
                        user.TID = team;
                    }

                    
                    db.Players.InsertOnSubmit(user);

                   
                    try
                    {
                        db.SubmitChanges();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("You have successfully registered!");
                    Window BacktoMain = new MainWindow();
                    BacktoMain.Show();
                    this.Close();
                    
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
                    msg.Body = "Congratulations!\nPlease follow the link below to verify your submission.\n\nhttp://basesloadedapp.azurewebsites.net/";
                    client.Send(msg);
                    MessageBox.Show("Please check your E-Mail for a verification link.");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            _applicant = new RegisterValidation();
            Register_Window.DataContext = _applicant;
            e.Handled = true;
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

        private void Team_Captain_Checked(object sender, RoutedEventArgs e)
        {
            CustomTeam.Visibility = Visibility.Visible;
            TeamList.Visibility = Visibility.Hidden;
            CustomTeamLabel.Visibility = Visibility.Visible;
            TeamListLabel.Visibility = Visibility.Hidden;
            
        }

        private void Team_Player_Checked(object sender, RoutedEventArgs e)
        {
            TeamList.Visibility = Visibility.Visible;
            CustomTeam.Visibility = Visibility.Hidden;
            CustomTeamLabel.Visibility = Visibility.Hidden;
            TeamListLabel.Visibility = Visibility.Visible;

            
        }

        

    }
}

            

 

