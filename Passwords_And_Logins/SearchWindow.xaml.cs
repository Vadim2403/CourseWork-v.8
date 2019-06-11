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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        List<Account> forFind = new List<Account>();
        public SearchWindow()
        {
            InitializeComponent();
            GridOFFindedaccounts.ItemsSource = forFind;
        }
        public void SearchLogin()
        {
            forFind.Clear();
            for (int i = 0; i < ((UserWindow)this.Owner).accounts.Count; i++)
            {
                if (((UserWindow)this.Owner).accounts[i].Login == SearchText.Text)
                {
                    forFind.Add(((UserWindow)this.Owner).accounts[i]);
                }
            }
            GridOFFindedaccounts.Items.Refresh();
        }
        public void SearchPassword()
        {
            forFind.Clear();
            for (int i = 0; i < ((UserWindow)this.Owner).accounts.Count; i++)
            {
                if (((UserWindow)this.Owner).accounts[i].Password == SearchText.Text)
                {
                    forFind.Add(((UserWindow)this.Owner).accounts[i]);
                }
            }
            GridOFFindedaccounts.Items.Refresh();
        }
        public void SearchLink()
        {
            forFind.Clear();
            for (int i = 0; i < ((UserWindow)this.Owner).accounts.Count; i++)
            {
                if (((UserWindow)this.Owner).accounts[i].Link == SearchText.Text)
                {
                    forFind.Add(((UserWindow)this.Owner).accounts[i]);
                }
            }
            GridOFFindedaccounts.Items.Refresh();
        }

        public void SearchSiteName()
        {
            forFind.Clear();
            for (int i = 0; i < ((UserWindow)this.Owner).accounts.Count; i++)
            {
                if (((UserWindow)this.Owner).accounts[i].SiteName == SearchText.Text)
                {
                    forFind.Add(((UserWindow)this.Owner).accounts[i]);
                }
            }
            GridOFFindedaccounts.Items.Refresh();
        }
        public void SearchInDesck()
        {
            forFind.Clear();
            for (int i = 0; i < ((UserWindow)this.Owner).accounts.Count; i++)
            {
                if (((UserWindow)this.Owner).accounts[i].Description.Contains(SearchText.Text))
                {
                    forFind.Add(((UserWindow)this.Owner).accounts[i]);
                }
            }
            GridOFFindedaccounts.Items.Refresh();
        }
        private void StartSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SearchByLogin.IsChecked == true)
                SearchLogin();
            else if (SearchByPassword.IsChecked == true)
                SearchPassword();
            else if (SearchBySiteName.IsChecked == true)
                SearchSiteName();
            else if (SearchByLink.IsChecked == true)
                SearchLink();
            else if (SearchinDescription.IsChecked == true)
                SearchInDesck();
        }
    }

}
