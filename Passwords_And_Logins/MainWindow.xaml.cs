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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Passwords_And_Logins
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> List_for_users = new List<User>();
        public int current_user = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            SignInBtn.IsEnabled = false;
            SignUpBtn.IsEnabled = false;

            Window1 signInWindow = new Window1();
            signInWindow.Owner = this;
            signInWindow.Show();


        }
        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            SignInBtn.IsEnabled = false;
            SignUpBtn.IsEnabled = false;

            SighUpWindow signUpWindow = new SighUpWindow();
            signUpWindow.Owner = this;
            signUpWindow.Show();



        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Account> accounts = new List<Account>();
    }
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Link { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }
    }
}
