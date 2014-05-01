using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace OpeningPitch    
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LINQtoSQLDataContext user = new LINQtoSQLDataContext();

        public MainWindow()
        {
            InitializeComponent();
            Username_Input.Focus();
        }

        //Funcionality of movable window
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            try
            {
                this.DragMove();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Window RegisterWindow = new RegisterWindow();
            RegisterWindow.Show();
            this.Close();
        }

        private void Log_In_Click(object sender, RoutedEventArgs e)
        {
            if (Username_Input.Text.Equals("") || Password_Input.Password.Equals(""))
            {
                MessageBox.Show("You did not enter a valid Username and/or Password");
            }
            else
            {
                var query = from players in user.Players
                            where (players.Email == Username_Input.Text && players.Password == Password_Input.Password)
                            select players;

                foreach (var player in query)
                {
                    if (query.Count() == 0)
                    {
                        MessageBox.Show("Incorrect email and password");
                    }

                    else if (player.UserType == 0)
                    {
                        globals.user.PID = player.PID;
                        globals.user.TID = player.TID;
                        globals.user.FirstName = player.FirstName;
                        globals.user.LastName = player.LastName;
                        globals.user.Email = player.Email;
                        globals.user.PhoneNumber = player.PhoneNumber;
                        globals.user.Address = player.Address;
                        globals.user.Address2 = player.Address2;
                        globals.user.City = player.City;
                        globals.user.State = player.State;
                        globals.user.Zipcode = player.Zipcode;
                        globals.user.Position = player.Position;
                        globals.user.AltPosition = player.AltPosition1;
                        globals.user.AltPosition2 = player.AltPosition2;
                        globals.user.Gender = player.Gender;
                        globals.user.UserType = player.UserType;
                        globals.user.Approved = player.Approved;
                        Window UserDashboard = new UserDashboard();
                        UserDashboard.Show();
                        this.Close();
                    }

                    else if (player.UserType == 1)
                    {
                        globals.user.PID = player.PID;
                        globals.user.TID = player.TID;
                        globals.user.FirstName = player.FirstName;
                        globals.user.LastName = player.LastName;
                        globals.user.Email = player.Email;
                        globals.user.PhoneNumber = player.PhoneNumber;
                        globals.user.Address = player.Address;
                        globals.user.Address2 = player.Address2;
                        globals.user.City = player.City;
                        globals.user.State = player.State;
                        globals.user.Zipcode = player.Zipcode;
                        globals.user.Position = player.Position;
                        globals.user.AltPosition = player.AltPosition1;
                        globals.user.AltPosition2 = player.AltPosition2;
                        globals.user.Gender = player.Gender;
                        globals.user.UserType = player.UserType;
                        globals.user.Approved = player.Approved;
                        Window Dashboard = new Dashboard();
                        Dashboard.Show();
                        this.Close();
                    }

                    if (Username_Input.Text.Equals("1") && Password_Input.Password.Equals("1"))
                    {
                        Window Dashboard = new Dashboard();
                        Dashboard.Show();
                        this.Close();
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit the application?",
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
    }
}
