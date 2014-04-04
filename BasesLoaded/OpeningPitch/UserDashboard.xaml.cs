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
        private void Player_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public UserDashboard()
        {
            InitializeComponent();
        }

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        private void GridViewRoster()
        {
            var players = (from m in db.Players
                           where m.TID == globals.user.TID
                           select m);

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
            MainWindow BacktoMain = new MainWindow();
            BacktoMain.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit?\n\nAll unsaved changes will be lost.",
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
        private void Minimize_Button(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void UserViewRoster_btn_Click(object sender, RoutedEventArgs e)
        {
            GridViewRoster();
        }

        private void EditInfo_btn_Click(object sender, RoutedEventArgs e)
        {
            CurrentUserInfo();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            LINQtoSQLDataContext UpdateUser = new LINQtoSQLDataContext();

            try
            {

                Player PlayerRow = User_View.SelectedItem as Player;
                //string m = PlayerRow.PID;
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
