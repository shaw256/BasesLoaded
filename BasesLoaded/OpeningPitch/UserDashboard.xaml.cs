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
            DataTable MyDataTable = new DataTable();

            MyDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "First Name"
                }

              );

            MyDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "Last Name"
                }
                );

            MyDataTable.Columns.Add(
               new DataColumn()
               {
                   DataType = System.Type.GetType("System.String"),
                   ColumnName = "Position"
               }
               );

            var applicationQuery = from players in db.Players
                                   where players.TID == globals.user.TID
                                   select players;


            foreach (var column in applicationQuery)
            {
                var row = MyDataTable.NewRow();
                row["First Name"] = column.FirstName;
                row["Last Name"] = column.LastName;
                row["Position"] = column.Position;
                MyDataTable.Rows.Add(row);
            }

            User_View.ItemsSource = MyDataTable.AsDataView();
            
            User_View.IsReadOnly = true;
            
        }
        private void CurrentUserInfo()
        {
            DataTable MyDataTable = new DataTable();

            MyDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "First Name"
                }

              );

            MyDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "Last Name"
                }
                );

            MyDataTable.Columns.Add(
               new DataColumn()
               {
                   DataType = System.Type.GetType("System.String"),
                   ColumnName = "Position"
               }
               );

            var applicationQuery = from players in db.Players
                                   where players.PID == globals.user.PID
                                   select players;


            foreach (var column in applicationQuery)
            {
                var row = MyDataTable.NewRow();
                row["First Name"] = column.FirstName;
                row["Last Name"] = column.LastName;
                row["Position"] = column.Position;
                MyDataTable.Rows.Add(row);
            }

            User_View.ItemsSource = MyDataTable.AsDataView();
            User_View.IsReadOnly = false;
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
                var query = from stuff in db.Players
                            where stuff.Email == globals.user.Email
                            select stuff;

                foreach (var stuff in query)
                {
                    stuff.FirstName = globals.user.FirstName;
                    stuff.LastName = globals.user.LastName;
                    stuff.Email = globals.user.Email;
                    stuff.PhoneNumber = globals.user.PhoneNumber;
                    stuff.Address = globals.user.Address;
                    stuff.Address2 = globals.user.Address2;
                    stuff.City = globals.user.City;
                    stuff.Zipcode = globals.user.Zipcode;
                    stuff.Position = globals.user.Position;
                    stuff.AltPosition1 = globals.user.AltPosition;
                    stuff.AltPosition2 = globals.user.AltPosition2;
                    stuff.Gender = globals.user.Gender;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
