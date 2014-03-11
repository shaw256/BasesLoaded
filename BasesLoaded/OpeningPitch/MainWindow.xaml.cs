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

namespace BasesLoaded    
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Log_In(object sender, RoutedEventArgs e)
        {
            //if ( = null)
            //{
            MessageBox.Show("You did not enter a valid Username and/or Password");
            //}
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Are you sure you would like to Exit the program?");

            //MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit the program?", "Exit", MessageBoxButton.OK);

            //if (result == MessageBoxResult.OK)
            //{
            //    this.Close();
            //      Application curApp = Application.Current;
            //    curApp.Shutdown();
            //}

            MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
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
