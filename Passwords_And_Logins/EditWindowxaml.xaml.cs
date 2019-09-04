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
    /// Логика взаимодействия для EditWindowxaml.xaml
    /// </summary>
    public partial class EditWindowxaml : Window
    {
        public string Description_for_nextWindow;
        public Account acc;
        public EditWindowxaml(Account acc)
        {
            InitializeComponent();
            this.acc = acc;
            Login.Text = acc.Login;
            Password.Text = acc.Password;
            Description_for_nextWindow = acc.Description;
        }

        private void FinishAddingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SnackbarBadPassword.IsActive == false)
            {
                Context c = new Context();
                foreach (var p in c.accounts)
                {
                    if (p.Login == acc.Login && p.Link == acc.Link)
                    {
                        p.Login = Login.Text;
                        p.Password = Password.Text;
                        p.Description = Description_for_nextWindow;
                        break;
                    }
                }
                c.SaveChanges();
                acc.Login = Login.Text;
                acc.Password = Password.Text;
                acc.Description = Description_for_nextWindow;


                ((UserWindow)this.Owner).GridOFaccounts.Items.Refresh();
                this.Close();
            }
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool bad = false;
            for (int i = 0; i < Password.Text.Length; i++)
            {
                if (Password.Text[i] == ' ' || Password.Text[i] == '/' || Password.Text[i] == '*' | Password.Text[i] == '.' | Password.Text[i] == ',')
                    bad = true;
            }
            if (Password.Text.Length < 6 || bad == true)
            {
                SnackbarBadPassword.IsActive = true;
            }
            else SnackbarBadPassword.IsActive = false;
        }
        private void NeedDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            DescriptionWindow descriptionWindow = new DescriptionWindow();
            descriptionWindow.Owner = this;
            descriptionWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.WindowState = WindowState.Maximized;
            this.Owner.WindowState = WindowState.Normal;
        }
    }
}
