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
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

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
            Approve_Player.Visibility = Visibility.Hidden;
            Deny_Player.Visibility = Visibility.Hidden;
            Cancel_Event.Visibility = Visibility.Hidden;
            Add_Player.Visibility = Visibility.Hidden;
            Delete_Player.Visibility = Visibility.Hidden;
        }

        LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        private void GridViewApplicants()
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

        private void GridViewRoster()
        {
            var players = (from m in db.Players
                           where m.TID == globals.user.TID
                           select m);

            Team_Display.ItemsSource = players;
        }

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
           Window Teams = new Add_Team();
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

           GridViewApplicants();
           Approve_Player.Visibility = Visibility.Visible;
           Deny_Player.Visibility = Visibility.Visible;
           Cancel_Event.Visibility = Visibility.Visible;
           
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
               //db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, info.Approved);
               db.SubmitChanges();
           }

           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

           GridViewApplicants();
       }
    
       

        private void Edit_Roster_click(object sender, RoutedEventArgs e)
        {
            Add_Player.Visibility = Visibility.Visible;
            Delete_Player.Visibility = Visibility.Visible;
            Approve_Player.Visibility = Visibility.Hidden;
            Deny_Player.Visibility = Visibility.Hidden;
            Cancel_Event.Visibility = Visibility.Hidden;           

        }

        private void Login_Home_Click(object sender, RoutedEventArgs e)
        {
            //Approve_Player.Visibility = Visibility.Hidden;
           // Deny_Player.Visibility = Visibility.Hidden;
            //Cancel_Event.Visibility = Visibility.Hidden;
            //Add_Player.Visibility = Visibility.Hidden;
            //Delete_Player.Visibility = Visibility.Hidden;
            Window home = new Dashboard();
            home.Show();
            this.Close();
          
        }

        private void EditInfo_btn_Click(object sender, RoutedEventArgs e)
        {
            Approve_Player.Visibility = Visibility.Hidden;
            Deny_Player.Visibility = Visibility.Hidden;
            Cancel_Event.Visibility = Visibility.Hidden;
            Add_Player.Visibility = Visibility.Hidden;
            Delete_Player.Visibility = Visibility.Hidden;
        }

        private void Deny_Player_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    SmtpClient client = new SmtpClient("smtp.live.com", 587);
            //    client.EnableSsl = true;
            //    client.Timeout = 10000;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = new NetworkCredential("basesloadedapp@outlook.com", "!QAZ@WSX1qaz2wsx");

            //    MailMessage msg = new MailMessage();
            //    msg.To.Add(Email_Input.Text);
            //    msg.From = new MailAddress("basesloadedapp@outlook.com");
            //    msg.Subject = "Registration Failed";
            //    msg.Body = "We are sorry to have to inform you that your submission has been denied.\nPlease contact the team captain";
            //    client.Send(msg);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void View_Team_Roster_Click(object sender, RoutedEventArgs e)
        {           
            //List<Player> Players = (from p in db.Players
            //IEnumerable<Player> Players= (from p in db.Players
            //                       where  p.Approved==1 && p.TID==3
            //                       orderby p.PID
            //                       select p).ToList();


            //Team_Display.ItemsSource = Players;

            GridViewRoster();

           
           

        }
    }   
           
}

