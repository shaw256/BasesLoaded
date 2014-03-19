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
    /// Interaction logic for Player_Info.xaml
    /// </summary>
    public partial class Player_Info : Window
    {
        public Player_Info()
        {
            InitializeComponent();
        }

        private void CancelForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlayerformReset_Click(object sender, RoutedEventArgs e)
        {
            // The code to clear the form will go here.
        }

        private void PlayerInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
