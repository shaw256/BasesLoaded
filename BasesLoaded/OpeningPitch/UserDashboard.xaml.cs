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
            Update.Visibility = Visibility.Hidden;
        }

        private void Player_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        private void GridViewRoster()
        {
            var players = (from m in db.Players
                           where m.TID == globals.user.TID
                           select m
                           );

            User_View.ItemsSource = players;
        }

        private void CurrentUserInfo()
        {
            var players = (from m in db.Players
                           where m.Email == globals.user.Email
                           select m);

            User_View.ItemsSource = players;
        }

        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to logout " + globals.user.FirstName + " ?\n\nAll unsaved changes will be lost", "Logout?", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                BacktoMain.Username_Input.Text = globals.user.Email;
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {

            }

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit, " + globals.user.FirstName + " ?\n\nAll unsaved changes will be lost.",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                MainWindow BacktoMain = new MainWindow();
                BacktoMain.Show();
                BacktoMain.Username_Input.Text = globals.user.Email;
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
                //if(column name condition of column id)
                item.IsReadOnly = true;
            }
        }

        private void EditInfo_btn_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserInfo();
            foreach (DataGridColumn item in User_View.Columns)
            {
                //if(column name condition of column id)
                item.IsReadOnly = false;
            }
            Update.Visibility = Visibility.Visible;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            LINQtoSQLDataContext UpdateUser = new LINQtoSQLDataContext();

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

                MessageBox.Show("Update Successful.");

                User_View.Items.Refresh();
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            } 
        }
    }
}
