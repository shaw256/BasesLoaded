using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

namespace OpeningPitch
{
    /// <summary>
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {
        public UserDashboard()
        {
            InitializeComponent();
            User_View.Visibility = Visibility.Hidden;
            //Update and Cancel button visibility is hidden upon window loading
            Update.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
        }

        private void Player_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Allows user to drag window
            this.DragMove();
        }

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        //Function that allows the current user to view the Team Roster
        private void GridViewRoster()
        {
            User_View.Visibility = Visibility.Visible;
            var players = (from m in db.Players
                           //Selects Team Identification associated with the current user
                           where m.TID == globals.user.TID
                           select m
                           );

            User_View.ItemsSource = players;
        }

        //Function that allows the current user to view his own information
        private void CurrentUserInfo()
        {
            User_View.Visibility = Visibility.Visible;
            emailField.Visibility = Visibility.Visible;
            phoneNumber.Visibility = Visibility.Visible;
            address1.Visibility = Visibility.Visible;
            address2.Visibility = Visibility.Visible;
            city.Visibility = Visibility.Visible;
            state.Visibility = Visibility.Visible;
            zipcode.Visibility = Visibility.Visible;
            Update.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;
            var players = (from m in db.Players
                           //Selects E-mail and associatd information with the current user
                           where m.Email == globals.user.Email
                           select m);

            User_View.ItemsSource = players;
        }

        //Logout function that also asks for confirmation from user
        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to logout " + globals.user.FirstName + " ?\n\nAll unsaved changes will be lost", "Logout?", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                BacktoMain.Username_Input.Text = globals.user.Email;
                BacktoMain.Password_Input.Focus();
                globals.Flush();
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                //Else do nothing
            }

        }

        //Exit button that also asks for user confirmation
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit, " + globals.user.FirstName + " ?\n\nAll unsaved changes will be lost.",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                //Takes the user back to the MainWindow but also populates the log-in field with current users e-mail
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                BacktoMain.Username_Input.Text = globals.user.Email;
                BacktoMain.Password_Input.Focus();
                globals.Flush();
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                //Else do nothing
            }
        }

        //Minimize button
        private void Minimize_Button(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Upon clicking the View Roster button, the user can view the current roster associated with their Team ID
        //The other users personal information is also hidden for security purposes
        private void UserViewRoster_btn_Click(object sender, RoutedEventArgs e)
        {
            GridViewRoster();
            emailField.Visibility = Visibility.Hidden;
            phoneNumber.Visibility = Visibility.Hidden;
            address1.Visibility = Visibility.Hidden;
            address2.Visibility = Visibility.Hidden;
            city.Visibility = Visibility.Hidden;
            state.Visibility = Visibility.Hidden;
            zipcode.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;

            foreach (DataGridColumn item in User_View.Columns)
            {
                //Makes the columns read-only
                item.IsReadOnly = true;
            }
        }

        //Upon clicking the Edit Info button, the current user can edit ONLY his personal information
        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserInfo();

            foreach (DataGridColumn item in User_View.Columns)
            {
                //Makes the columns editable to the current user
                item.IsReadOnly = false;
            }
            //Allows the Update button to be visible upon Edit Info button click
            Update.Visibility = Visibility.Visible;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            LINQtoSQLDataContext UpdateUser = new LINQtoSQLDataContext();

            //Pushes all columns back to the database column associated with the current users Player ID
            try
            {
                Player PlayerRow = User_View.SelectedItem as Player;
                Player player = (from p in UpdateUser.Players
                                     where p.PID == globals.user.PID
                                     select p).Single();

                player.FirstName = PlayerRow.FirstName;
                player.LastName = PlayerRow.LastName;
                player.Email = PlayerRow.Email;
                player.PhoneNumber = PlayerRow.PhoneNumber;
                player.Address = PlayerRow.Address;
                player.Address2 = PlayerRow.Address2;
                player.City = PlayerRow.City;
                player.State = PlayerRow.State;
                player.Zipcode = PlayerRow.Zipcode;

                UpdateUser.SubmitChanges();

                //Update Confirmation
                MessageBox.Show("Update Successful.");

                //Refreshes every column, updated or not
                User_View.Items.Refresh();
            }

            catch (Exception Ex)
            {
                //Shows exception in messagebox
                MessageBox.Show(Ex.Message);
                return;
            } 
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            User_View.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to Cancel, " + globals.user.FirstName + " ?\n\nYour changes will be lost.",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                CurrentUserInfo();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                //Else do nothing
            }
        }
    }
}
