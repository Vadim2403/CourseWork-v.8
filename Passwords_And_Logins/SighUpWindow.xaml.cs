using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (SnackbarBadConfPassword.IsActive == true || SnackbarBadEmail.IsActive == true || SnackbarBadLogin.IsActive == true || SnackbarBadPassword.IsActive == true || PassField.Password.Length == 0 || ConfPassField.Password.Length == 0||LoginBox.Text==""||EmailBox.Text=="")
            { }
            else
                {
                Context c = new Context();
                c.users.Add(new User { Email = EmailBox.Text, Password = PassField.Password.ToString(), Login = LoginBox.Text, accounts = new List<Account>() });
                c.SaveChanges();
                ((MainWindow)this.Owner).UpdateList();
                this.Close();
            }
        }

        private void ConfPassField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassField.Password.ToString() != ConfPassField.Password.ToString())
            {
                SnackbarBadConfPassword.IsActive = true;
            }
                //FailConfirmPass.Visibility = Visibility.Visible;
            else
                SnackbarBadConfPassword.IsActive = false;

        }

        private void LoginBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == "")
                SnackbarBadLogin.IsActive = true;
            bool find = false;
            for (int i = 0; i < ((MainWindow)Owner).List_for_users.Count; i++)
            {
                if (((MainWindow)Owner).List_for_users[i].Login == LoginBox.Text)
                {
                    SnackbarBadLogin.IsActive = true;
                    find = true;
                    break;
                }
            }
            if (find == false)
                SnackbarBadLogin.IsActive = false;
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == "")
                SnackbarBadEmail.IsActive = true;
  
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(EmailBox.Text))
            {
                bool find = false;
                for (int i = 0; i < ((MainWindow)Owner).List_for_users.Count; i++)
                {
                    if (((MainWindow)Owner).List_for_users[i].Email == EmailBox.Text)
                    {
                        SnackbarBadEmail.IsActive = true;
                        find = true;
                        break;
                    }
                }
                if (find == false)
                    SnackbarBadEmail.IsActive = false;
            }
            else 
                SnackbarBadEmail.IsActive = true;
          

        }

 

        private void PassField_PasswordChanged(object sender, RoutedEventArgs e)
        {
            bool bad = false;
            string pass = PassField.Password.ToString();
            for(int i = 0; i < PassField.Password.Length; i++)
            {
                if (pass[i] == ' ' || pass[i] == '/' || pass[i] == '*' | pass[i] == '.' | pass[i] == ',')
                    bad = true;
            }
            if (PassField.Password.Length < 6 || bad == true)
            {
                SnackbarBadPassword.IsActive = true;
            }
            else SnackbarBadPassword.IsActive = false;

        }
    }
}
