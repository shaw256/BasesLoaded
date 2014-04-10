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
            Update.Visibility = Visibility.Hidden;
            Team_Display.Visibility = Visibility.Hidden;
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
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to logout " + globals.user.FirstName +"?\n\nAll unsaved changes will be lost.",
                          "Confirmation", MessageBoxButton.OKCancel);

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

            }
        }
     
       private void Exit_Click(object sender, RoutedEventArgs e)
       {
           MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit "+globals.user.FirstName+"?\n\nAll unsaved changes will be lost.",
               "Confirmation", MessageBoxButton.OKCancel);

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

           }
       }
       private void Minimize_Button(object sender, RoutedEventArgs e)
       {
           this.WindowState = WindowState.Minimized;
       }

       private void Applications_Click(object sender, RoutedEventArgs e)
       {
           
           GridViewApplicants();
           MakeReadonlyFalse();
           Add_Player.Visibility = Visibility.Hidden;
           Delete_Player.Visibility = Visibility.Hidden;
           Approve_Player.Visibility = Visibility.Visible;
           Deny_Player.Visibility = Visibility.Visible;
           Cancel_Event.Visibility = Visibility.Visible;
           Update.Visibility = Visibility.Hidden;
         
           
       }

       private void Approve_Player_Click(object sender, RoutedEventArgs e)
       {
           try
           {

               Player PlayerRow = Team_Display.SelectedItem as Player;

               Player selectedPlayer = (from p in db.Players
                                where p.PID == globals.user.PID
                                select p).Single();

               selectedPlayer.Approved = 1;
               try
               {
                   db.SubmitChanges();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + "Update Unsuccessfull");
               }
               MessageBox.Show("Update Successful.");

               Team_Display.Items.Refresh();

           }

           catch (Exception Ex)
           {

               MessageBox.Show(Ex.Message);

               return;
           }
           //DataRowView row = (DataRowView)Team_Display.SelectedItems[0];
           //var player = from players in db.Players
           //             where players.Email.ToString() == row["Email"].ToString()
           //             select players;

           //foreach (var info in player)
           //{
           //    info.Approved = 1;

           //}
           //try
           //{
           //    //db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, info.Approved);
           //    db.SubmitChanges();
           //}

           //catch (Exception ex)
           //{
           //    MessageBox.Show(ex.Message);
           //}

           GridViewApplicants();
       }
    
       

        private void Login_Home_Click(object sender, RoutedEventArgs e)
        {
            Approve_Player.Visibility = Visibility.Hidden;
            Deny_Player.Visibility = Visibility.Hidden;
            Cancel_Event.Visibility = Visibility.Hidden;
            Add_Player.Visibility = Visibility.Hidden;
            Delete_Player.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Team_Display.Visibility = Visibility.Hidden;
          
        }

        private void EditPersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            Approve_Player.Visibility = Visibility.Hidden;
            Deny_Player.Visibility = Visibility.Hidden;
            Cancel_Event.Visibility = Visibility.Visible;
            Add_Player.Visibility = Visibility.Hidden;
            Delete_Player.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Visible;
            CurrentUserInfo();
          
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

        private void Team_Roster_Click(object sender, RoutedEventArgs e)
        {
            Approve_Player.Visibility = Visibility.Hidden;
            Deny_Player.Visibility = Visibility.Hidden;
            Cancel_Event.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            Add_Player.Visibility = Visibility.Visible;
            Delete_Player.Visibility = Visibility.Visible;
            GridViewRoster();
            MakeReadonlyTrue();
        }

        private void Add_Player_Click(object sender, RoutedEventArgs e)
        {
            Window AddPlayer = new Player_Info();
            AddPlayer.Show();
            MakeReadonlyTrue();
            this.Close();
        }
      
        private void Update_Click(object sender, RoutedEventArgs e)
        {
             

             try
             {

                 Player PlayerRow = Team_Display.SelectedItem as Player;

                 Player player = (from p in db.Players
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

                 db.SubmitChanges();

                 MessageBox.Show("Update Successful.");

                 Team_Display.Items.Refresh();

             }

             catch (Exception Ex)
             {

                 MessageBox.Show(Ex.Message);

                 return;
             }
        }
        private void Delete_Player_Click(object sender, RoutedEventArgs e)
        {
            Player selectedPlayer = Team_Display.SelectedItem as Player;

            var queriedPlayer = from players in db.Players
                                where players.PID == selectedPlayer.PID
                                select players;

            foreach (var playerDetails in queriedPlayer)
            {
                db.Players.DeleteOnSubmit(playerDetails);
            }

            try
            {
                db.SubmitChanges();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            GridViewRoster();

        }
        /// extra functions that the click buttons use
        /// 
            private void GridViewRoster()
            {
                Team_Display.Visibility = Visibility.Visible;
                var players = (from m in db.Players
                               where m.TID == globals.user.TID && m.Approved == 1
                               select m);

                Team_Display.ItemsSource = players;
            }
        
            private void GridViewApplicants()
            {
                Team_Display.Visibility = Visibility.Visible;
                var players = (from a in db.Players
                               where a.Approved == 0
                               select a);
                Team_Display.ItemsSource = players;
            }

            private void MakeReadonlyTrue()
            {
                foreach (DataGridColumn Item in Team_Display.Columns)
                {
                    Item.IsReadOnly = true;
                }
            }
        
            private void MakeReadonlyFalse()
            {
                foreach (DataGridColumn Item in Team_Display.Columns)
                {
                    Item.IsReadOnly = false;
                }
            }
            
            private void CurrentUserInfo()
            {
                Team_Display.Visibility = Visibility.Visible;
                var players = (from m in db.Players
                               where m.Email == globals.user.Email
                               select m);

                Team_Display.ItemsSource = players;
                MakeReadonlyFalse();
            }


        }

    }   
           


