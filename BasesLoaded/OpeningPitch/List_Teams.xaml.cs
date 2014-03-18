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

        private void Create_Team_Click(object sender, RoutedEventArgs e)
        {
            team_listbox.Items.Add(txt_TeamName);
            txt_TeamName.Clear();
        }

        private void Delete_Team_Click(object sender, RoutedEventArgs e)
        {
            team_listbox.Items.Remove(txt_TeamName);
            txt_TeamName.Clear();

        }

        private void team_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Once the team is added to the list box, this code will allow the captain to assign player in his team by double clicking in the
            //desired team.
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}




