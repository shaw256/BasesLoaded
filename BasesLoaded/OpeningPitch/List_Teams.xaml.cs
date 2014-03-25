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
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Create_Team1_Click(object sender, RoutedEventArgs e)
        {
            Team_Listbox.Items.Add(Team_Name_Input);
            Team_Name_Input.Clear();
        }
        private void Delete_Team_Click(object sender, RoutedEventArgs e)
        {
            Team_Listbox.Items.Remove(Team_Name_Input);
            Team_Name_Input.Clear();
        }
        private void Team_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Once the team is added to the list box, this code will allow the captain to assign player in his team by double clicking in the
            //desired team.
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit the application?",
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
        private void Login_Home_Click(object sender, RoutedEventArgs e)
        {
            Window Dashboard = new Dashboard();
            Dashboard.Show();
        }
    }
}




