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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool Succsesful_login = false;

        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Succsesful_login == false)
            {
                ((MainWindow)Owner).SignInBtn.IsEnabled = true;
                ((MainWindow)Owner).SignUpBtn.IsEnabled = true;
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            bool log_true = false;
            for (int i = 0; i < ((MainWindow)Owner).List_for_users.Count; i++)
            {
                if (((MainWindow)Owner).List_for_users[i].Login == LoginBox.Text)
                {
                    log_true = true;
                    SnackbarBadLogin.IsActive = false;
                    if (((MainWindow)Owner).List_for_users[i].Password == PassField.Password.ToString())
                    {
                        ((MainWindow)this.Owner).current_user = i;
                        UserWindow userWindow = new UserWindow(((MainWindow)this.Owner).List_for_users, ((MainWindow)this.Owner).current_user);
                        userWindow.Owner = this.Owner;
                        userWindow.Show();
                        userWindow.TextUserName.Text = "You are logged in as : " +  LoginBox.Text;
                        ((MainWindow)this.Owner).current_user = i;
                        Succsesful_login = true;
                        this.Close();

                    }
                    else
                    {
                        SnackbarBadPassword.IsActive = true;
                        break;
                    }
                }
            }
            if(log_true==false)
            {
                SnackbarBadLogin.IsActive = true;
            }
        }
    }
}
