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
                                   where players.Approved == 0
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
            

        }
    }
}
