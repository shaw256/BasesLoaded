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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {

            InitializeComponent();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Window Profile = new Dashboard();
            Profile.Show();
        }

        private void Dashboard_Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       private void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            //Window Teams = new List_Teams();
            //Teams.Show();
        }


    }              
}

