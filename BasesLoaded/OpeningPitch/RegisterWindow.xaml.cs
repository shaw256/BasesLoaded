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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void First_Name(object sender, TextChangedEventArgs e)
        {

        }

        private void Last_Name(object sender, TextChangedEventArgs e)
        {

        }

        private void E_Mail(object sender, TextChangedEventArgs e)
        {

        }

        private void D_O_B(object sender, TextChangedEventArgs e)
        {

        }

        private void Phone_Number(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
