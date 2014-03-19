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
    /// Interaction logic for Manage_Roster.xaml
    /// </summary>
    public partial class Manage_Roster : Window
    {
        private void Manage_Team_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public Manage_Roster()
        {
            InitializeComponent();
        }

        private void Player_Add_Click(object sender, RoutedEventArgs e)
        {
            Window playerinfo = new Player_Info();
            playerinfo.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit Registration?\n\nAll data will be lost.",
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
    }
}
