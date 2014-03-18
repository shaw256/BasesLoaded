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

        public MainWindow()
        {
            InitializeComponent();
            Username_Input.Focus();
            
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

            if (Username_Input.Text.Equals("1") && Password_Input.Password.Equals("1"))
            {
                Window Dashboard = new Dashboard();
                Dashboard.Show();
                this.Close();
            }
            if (Username_Input.Text.Equals("2") && Password_Input.Password.Equals("2"))
            {
                Window Dashboard = new UserDashboard();
                Dashboard.Show();
                this.Close();
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
    }
}
