﻿using System;
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
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {
        private void Player_Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow BacktoMain = new MainWindow();
            BacktoMain.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit?\n\nAll unsaved changes will be lost.",
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
