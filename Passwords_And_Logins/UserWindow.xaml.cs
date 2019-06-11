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

namespace Passwords_And_Logins
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        List<User> users;
        List<Account> accounts;
        int current;
        public UserWindow(List<User>users, int current)
        {
            InitializeComponent();
            this.users = users;
            this.current = current;
            accounts = users[current].accounts;
            GridOFaccounts.ItemsSource = accounts;
        }
    }
}
