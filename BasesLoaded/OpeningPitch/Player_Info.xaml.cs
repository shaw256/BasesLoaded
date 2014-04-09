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
    /// Interaction logic for Player_Info.xaml
    /// </summary>
    
    public partial class Player_Info : Window
    {

        private int _noOfErrorsOnScreen = 0;
        private RegisterValidation _applicant = new RegisterValidation();
        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public Player_Info()
        {
            InitializeComponent();

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

            RegisterValidation _applicant = PlayerInfo.DataContext as RegisterValidation;

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
                            where stuff.PhoneNumber == Phone_Input.Text
                            select stuff;

                if (query.Count() == 0)
                {

                    Player user = new Player();
                    user.FirstName = FirstName_Input.Text;
                    user.LastName = LastName_Input.Text;
                    user.PhoneNumber = Phone_Input.Text;
                    user.Address = Address1_Input.Text;
                    user.Address2 = Address2_Input.Text;
                    user.City = City_Input.Text;
                    user.State = State_Input.Text;
                    user.Zipcode = Zipcode_Input.Text;
                    user.Gender = Gender_Selection.Text;
                    user.Position = Position_Input.Text;
                    user.TeamName = TeamList.Text;

                    db.Players.InsertOnSubmit(user);


                    try
                    {
                        db.SubmitChanges();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("You have successfully Added a Player to the Team!");
                    Window BacktoMain = new Dashboard();
                    BacktoMain.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "You were unable to add the new player. Please check your entries and retry.");

            }

            _applicant = new RegisterValidation();
            PlayerInfo.DataContext = _applicant;
            e.Handled = true;
        }
        private void CancelForm_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to cancel. All data will be lost?",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Dashboard BacktoMain = new Dashboard();
                BacktoMain.Show();
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {

            }
        }

        private void PlayerformReset_Click(object sender, RoutedEventArgs e)
        {
            // The code to clear the form will go here.
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit the application?",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Dashboard BacktoMain = new Dashboard();
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

               
    }
}
