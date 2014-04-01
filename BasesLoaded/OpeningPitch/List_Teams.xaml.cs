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
    /// Interaction logic for List_Teams.xaml
    /// </summary>
    public partial class List_Teams : Window
    {
        public List_Teams()
        {
            InitializeComponent();
            Create_Team.Visibility = Visibility.Hidden;
            GridViewTeams();
        }

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        private void GridViewTeams()
        {
            DataTable TeamDataTable = new DataTable();

            TeamDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "Team ID"
                }

              );

            TeamDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "Team Name"
                }
                );

            TeamDataTable.Columns.Add(
                new DataColumn()
                {
                    DataType = System.Type.GetType("System.String"),
                    ColumnName = "Coach First Name"
                }
                );

            TeamDataTable.Columns.Add(
               new DataColumn()
               {
                   DataType = System.Type.GetType("System.String"),
                   ColumnName = "Coach Last Name"
               }
               );

            var applicationQuery = from teams in db.Teams
                                   where teams.TID <= 0
                                   select teams;


            foreach (var column in applicationQuery)
            {
                var row = TeamDataTable.NewRow();
                row["Team ID"] = column.TID;
                row["Team Name"] = column.TeamName;
                row["Coach First Name"] = column.CoachFirstName;
                row["Coach Last Name"] = column.CoachLastName;
                TeamDataTable.Rows.Add(row);
            }

            Team_GridBox.ItemsSource = TeamDataTable.AsDataView();
            Team_GridBox.IsReadOnly = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Create_Team_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var query = from stuff in db.Teams
                            where stuff.TeamName == Team_Name_Input.Text
                            select stuff;

                if (query.Count() == 0)
                {

                    Team newTeam = new Team();
                    newTeam.TeamName = Team_Name_Input.Text;
                    newTeam.CoachFirstName = Coach_First_Name.Text;
                    newTeam.CoachLastName = Coach_Last_Name.Text;


                    db.Teams.InsertOnSubmit(newTeam);

                    try
                    {
                        db.SubmitChanges();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ToolTip = "You have successfully registered!";

                    GridViewTeams();
                }

                else
                {
                    MessageBox.Show("Team already exists!");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Team_Name_Input.Clear();
        }
        
            
        
        private void Clear_Team_Name_Click(object sender, RoutedEventArgs e)
        {
            Team_Name_Input.Clear();
        }
        private void Team_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Once the team is added to the list box, this code will allow the captain to assign player in his team by double clicking in the
            //desired team.
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to cancel the team edit process?",
                "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Window Dashboard = new Dashboard();
                Dashboard.Show();
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
        private void Login_Home_Click(object sender, RoutedEventArgs e)
        {
            Window Dashboard = new Dashboard();
            Dashboard.Show();
            this.Close();
        }

        private void Unhide_Create_Button(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Team_Name_Input.Text))
            {
                Create_Team.Visibility = Visibility.Hidden;
                ToolTip = "Please enter or select a Team Name!";
            }
            else
            {
                Create_Team.Visibility = Visibility.Visible;
            }
        }

        
    }
}




