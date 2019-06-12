using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;

namespace Passwords_And_Logins
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        List<User> users;
        bool iscoded = false;
        public List<Account> accounts;
        int current;
        string Pstat;
        string Lstat;
        public UserWindow(List<User>users, int current)
        {
            InitializeComponent();
            this.users = users;
            this.current = current;
            accounts = users[current].accounts;
            GridOFaccounts.ItemsSource = accounts;
            GridOFaccounts.Items.Refresh();
        }



        private void NeedDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Owner = this;
            addWindow.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GridOFaccounts.SelectedItems.Count > 0)
            {
                EditWindowxaml editWindowxaml = new EditWindowxaml((Account)GridOFaccounts.SelectedItems[0]);
                editWindowxaml.Owner = this;
                editWindowxaml.Show();
            }
            else
                MessageBox.Show("Select item for edit");
        }
        public void code()
        {
            if (accounts.Count > 0)
            {
                string pass = "";
                Random r = new Random();
                for (int i = 0; i < accounts.Count; i++)
                {
                    pass = "";
                    for (int j = 0; j < accounts[i].Password.Length; j++)
                    {
                        int digit;

                        digit = Convert.ToInt32(accounts[i].Password[j]);
                        digit += 10;
                        if (digit > 255)
                            digit = 255;
                        pass = pass + (char)digit;




                    }
                    accounts[i].Password = pass;

                }
                CodeBtn.IsEnabled = false;
                DeCodeBtn.IsEnabled = true;
                iscoded = true;
                GridOFaccounts.Items.Refresh();
            }
        }
        public void Decode()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                string pass = "";
                for (int j = 0; j < accounts[i].Password.Length; j++)
                {
                    int digit = ((int)accounts[i].Password[j]) - 10;



                    pass = pass + (char)digit;

                   
                }
                accounts[i].Password = pass;
            }

            CodeBtn.IsEnabled = true;
            DeCodeBtn.IsEnabled = false;
            iscoded = false;
            GridOFaccounts.Items.Refresh();
        }
        private void CodeBtn_Click(object sender, RoutedEventArgs e)
        {
            code();
        }

        private void DeCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            Decode();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Owner = this;
            searchWindow.Show();
        }

        private void MostPopularLogins_Click(object sender, RoutedEventArgs e)
        {
            string most_popular_login ="";
            string login ="";
            int max = 0;
            int count = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                count = 0;
                login = accounts[i].Login;
                if (login == most_popular_login)
                    continue;
                for(int j = 0; j < accounts.Count; j++)
                {
                    if (login == accounts[j].Login)
                        count++;
                }
                if (count > max)
                {
                    max = count;
                    most_popular_login = login;
                }
            }
            MessageBox.Show("Most popular login is " + most_popular_login + " Finded - " + max.ToString() + " times");
        }


        private void ShowDialog_OnClick(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = true;
        }
        private void ShowDialog_OnClick_2(object sender, RoutedEventArgs e)
        {
            DialogHostFOrpass.IsOpen = true;
        }
        private void MostPopularPasses_Click(object sender, RoutedEventArgs e)
        {
            string most_popular_pass = "";
            string pass = "";
            int max = 0;
            int count = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                count = 0;
                pass = accounts[i].Password;
                if (pass == most_popular_pass)
                    continue;
                for (int j = 0; j < accounts.Count; j++)
                {
                    if (pass == accounts[j].Password)
                        count++;
                }
                if (count > max)
                {
                    max = count;
                    most_popular_pass = pass;
                }
            }
            MessageBox.Show("Most popular password is " + most_popular_pass + " Finded - " + max.ToString() + " times");
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            int count = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Login == LoginForStat.Text)
                    count++;
            }
            MessageBox.Show("Login - " + LoginForStat.Text + " Finded - " + count.ToString() + " times");
        }
        private void DialogHost_DialogClosing_pass(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            int count = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Password == PasswordForStat.Text)
                    count++;
            }
            MessageBox.Show("Password - " + PasswordForStat.Text + " Finded - " + count.ToString() + " times");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (iscoded == true)
            {
                Decode();

            }
            ((MainWindow)this.Owner).List_for_users[((MainWindow)this.Owner).current_user].accounts = accounts;
            ((MainWindow)this.Owner).SignInBtn.IsEnabled = true;
            ((MainWindow)this.Owner).SignUpBtn.IsEnabled = true;
            XmlSerializer ser = new XmlSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream("UsersAndAccounts.xml", FileMode.Create))
            {
                ser.Serialize(fs, ((MainWindow)this.Owner).List_for_users);
            }
            this.Owner.WindowState = WindowState.Maximized;
            this.Owner.WindowState = WindowState.Normal;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GridOFaccounts.SelectedItems.Count > 0)
            {
                accounts.RemoveAt(GridOFaccounts.SelectedIndex);
                GridOFaccounts.Items.Refresh();
            }
            else
                MessageBox.Show("Select item for edit");
        }

        private void PassAndLoginStat_Click(object sender, RoutedEventArgs e)
        {
            DialogLoginAndPass1.IsOpen = true;

        }

        private void DialogLoginAndPass1_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            Lstat = LoginStat.Text;
            DialogLoginAndPass2.IsOpen = true;
        }

        private void DialogLoginAndPass2_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            Pstat = PassStat.Text;
            int count = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Password == Pstat && accounts[i].Login == Lstat)
                    count++;
            }
            MessageBox.Show("Password - " + Pstat + " and login - " + Lstat + " Finded - " + count.ToString() + " times");
        }
    }
}
