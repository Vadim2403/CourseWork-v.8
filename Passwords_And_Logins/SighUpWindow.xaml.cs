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

namespace Passwords_And_Logins
{
    /// <summary>
    /// Логика взаимодействия для SighUpWindow.xaml
    /// </summary>
    public partial class SighUpWindow : Window
    {
        public bool closed = false;
        public SighUpWindow()
        {
            InitializeComponent();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ((MainWindow)Owner).SignInBtn.IsEnabled = true;
            ((MainWindow)Owner).SignUpBtn.IsEnabled = true;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Owner).List_for_users.Add(new User { Email = EmailBox.Text, Password = PassField.Password.ToString(), Login = LoginBox.Text, accounts=new List<Account>()});
            this.Close();
        }

        private void ConfPassField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassField.Password.ToString() != ConfPassField.Password.ToString())
                FailConfirmPass.Visibility = Visibility.Visible;
            else
                FailConfirmPass.Visibility = Visibility.Hidden;

        }

        private void LoginBox_LostFocus(object sender, RoutedEventArgs e)
        {
            bool find = false;
            for (int i = 0; i < ((MainWindow)Owner).List_for_users.Count; i++)
            {
                if (((MainWindow)Owner).List_for_users[i].Login == LoginBox.Text)
                {
                    FailLogin.Visibility = Visibility.Visible;
                    find = true;
                    break;
                }
            }
            if (find == false)
                FailLogin.Visibility = Visibility.Hidden;
        }
    }
}
