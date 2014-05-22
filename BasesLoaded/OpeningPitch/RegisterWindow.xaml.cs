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

    public partial class RegisterWindow : Window
    {

        //Instantiates a new applicant and a connection to the LINQ to SQL Database Markup Language//

        private int _noOfErrorsOnScreen = 0;
        private RegisterValidation _applicant = new RegisterValidation();
        LINQtoSQLDataContext db = new LINQtoSQLDataContext();


        //Allows the users to move the window around the screen//

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            try
            {
                this.DragMove();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
       
        //Initializes the Window, makes certain fields not visible unless the user selects certain options.//
        //Focuses the cursor in the first field for entry and creates a data context back to the RegisterValidation backer class//


        public RegisterWindow()
        {
            InitializeComponent();
            TeamList.Visibility = Visibility.Hidden;
            TeamListLabel.Visibility = Visibility.Hidden;
            CustomTeam.Visibility = Visibility.Hidden;
            CustomTeamLabel.Visibility = Visibility.Hidden;
            First_Name_Input.Focus();
            this.State_Input.SelectedIndex = 1;
            Register_Window.DataContext = _applicant;
            PopulateTeamComboBox();
        }
        
        //Populates the Team Combobox with the teams listed in the Database using the LINQ to SQL DBML//
        public void PopulateTeamComboBox()
        {
            var currentTeamQuery = (from teams in db.Teams
                            select new { teams.TeamName }).ToList();
            
            
            this.TeamList.ItemsSource = currentTeamQuery;
            this.TeamList.DisplayMemberPath = "TeamName";
            this.TeamList.SelectedValuePath = "TeamName";
            
        }

        //Increments a counter for every error identified, decremented if none found//

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }
        
        //Restricts the user's ability to register unless there are no errors//
        private void Applicant_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }
        

        //Binds the registration data to the LINQ to SQL dbml based on user specified entries//
        //Sends an email to the user provided email address//
        //Clears all textboxes and reestablished the datacontext to allow the user to enter again//

        private void Applicant_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           RegisterValidation _applicant = Register_Window.DataContext as RegisterValidation;

            if (Confirm_Password_Input.Text != New_Password_Input.Text)
            {
                MessageBox.Show("Your passwords must match before you can finish registering. Please check your password and try again.");
            }
            else
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
                    user.Password = Confirm_Password_Input.Text;
                                   
                    if (AccountType.Text == "Team Captain")
                    {
                        user.UserType = 1;
                        user.Approved = 1;
                        user.Position = "Team Captain";
                        user.TeamName = CustomTeam.Text;
                        globals.user.TID = user.TID;

                        globals.user.UserType = user.UserType;

                        Team newTeam = new Team();
                        newTeam.TeamName = CustomTeam.Text;
                        newTeam.CoachFirstName = First_Name_Input.Text;
                        newTeam.CoachLastName = Last_Name_Input.Text;

                        user.TeamName = CustomTeam.Text;
                        db.Teams.InsertOnSubmit(newTeam);
                    }

                    if (AccountType.Text == "Team Player")
                    {

                        var teamquery = from teams in db.Teams
                                        where teams.TeamName == TeamList.Text
                                        select teams;

                        foreach (var team in teamquery)
                        {
                            user.TID = team.TID;
                            user.TeamName = team.TeamName;

                        }
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

                    if (AccountType.Text == "Team Captain")
                    {
                        var teamquery = from teams in db.Teams
                                        where teams.TeamName == CustomTeam.Text
                                        select teams;

                        foreach (var team in teamquery)
                        {
                            globals.user.TID = team.TID;
                            user.TID = team.TID;
                        }
                        try
                        {
                            db.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("You have successfully registered!");

                    Window BacktoMain = new MainWindow();
                    BacktoMain.Show();
                    this.Close();
 
            try
                {
                    SmtpClient client = new SmtpClient("smtp.live.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("basesloadedapp@outlook.com", "1qaz2wsx!QAZ@WSX");

                    MailMessage msg = new MailMessage();
                    msg.To.Add(Email_Input.Text);
                    msg.From = new MailAddress("basesloadedapp@outlook.com");
                    msg.Subject = "Registration Successful";
                    msg.Body = "Congratulations!\nYou have successfully registered.";
                    client.Send(msg);
                    MessageBox.Show("Please check your E-Mail for verification.");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            
            _applicant = new RegisterValidation();
            Register_Window.DataContext = _applicant;
            e.Handled = true;

        }
        }
        //After user confirmation, navigates back to the main screen//
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

        //After user confirmation, navigates back to the main screen//
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

        //Removes the user selected Team entry//
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            TeamList.SelectedIndex = -1;
            CustomTeam.Text = "";
        }

        //Hides irrelevant databoxes and displays relevant databoxes//
        private void AccountType_DropDownClosed(object sender, EventArgs e)
        {
            if (AccountType.Text == "Team Captain")
            {
                TeamList.Visibility = Visibility.Hidden;
                TeamListLabel.Visibility = Visibility.Hidden;
                CustomTeam.Visibility = Visibility.Visible;
                CustomTeamLabel.Visibility = Visibility.Visible;
            }
            else
            {
                TeamList.Visibility = Visibility.Visible;
                TeamListLabel.Visibility = Visibility.Visible;
                CustomTeam.Visibility = Visibility.Hidden;
                CustomTeamLabel.Visibility = Visibility.Hidden;
            }
        }
      
  }

}  