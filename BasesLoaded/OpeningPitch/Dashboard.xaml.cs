using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        private void TC_Dashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Window Profile = new Dashboard();
            Profile.Show();
        }
        private void Dashboard_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow BacktoMain = new MainWindow();
            BacktoMain.Show();
            this.Close();
        }
       private void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            Window Teams = new List_Teams();
           Teams.Show();
           this.Close();
        }
       private void Exit_Click(object sender, RoutedEventArgs e)
       {
           MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit?\n\nAll unsaved changes will be lost.",
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

       private void Applications_Click(object sender, RoutedEventArgs e)
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
                   ColumnName = "Email"
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
               row["Email"] = column.Email;
               row["Position"] = column.Position;
               MyDataTable.Rows.Add(row);
           }

           Team_Display.ItemsSource = MyDataTable.AsDataView();
           Team_Display.IsReadOnly = true;

           
       }

       private void Approve_Player_Click(object sender, RoutedEventArgs e)
       {
           DataRowView row = (DataRowView)Team_Display.SelectedItems[0];
           var player = from players in db.Players
                        where players.Email.ToString() == row["Email"].ToString()
                        select players;

           foreach (var info in player)
           {
               info.Approved = 1;
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
    }              
}

