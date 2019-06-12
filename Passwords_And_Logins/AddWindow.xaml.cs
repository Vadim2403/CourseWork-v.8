using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public string desc = "";
        public AddWindow()
        {
            InitializeComponent();
        }

        private void FinishAddingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SnackbarBadPassword.IsActive == false && SnackbarBadLink.IsActive == false && Login.Text != "" && Password.Text != "" && Link.Text != "" && SiteName.Text != "") 
            {
                ((UserWindow)this.Owner).accounts.Add(new Account { Login = Login.Text, Description = desc, Link = Link.Text, Password = Password.Text, SiteName = SiteName.Text });
                ((UserWindow)this.Owner).GridOFaccounts.Items.Refresh();
                this.Close();
            }
        }

        private void NeedDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            DescriptionWindow descriptionWindow = new DescriptionWindow();
            descriptionWindow.Owner = this;
            descriptionWindow.DescText.Text = desc;
            descriptionWindow.Show();
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

      

        private void Link_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Link.Text.Length == 0)
            {
                SnackbarBadLink.IsActive = true;
            }
            else
            {
                string help = "https://";
                
                if (Link.Text.Contains(help))
                    help = "";
                WebRequest webRequest = HttpWebRequest.Create(help + Link.Text);
                webRequest.Method = "HEAD";
                try
                {
                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        SnackbarBadLink.IsActive = false;
                    }
                }
                catch (WebException ex)
                {
                    SnackbarBadLink.IsActive = true;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.WindowState = WindowState.Maximized;
            this.Owner.WindowState = WindowState.Normal;
        }
    }
}
