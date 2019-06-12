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
        
      
        public void SearchAcc()
        {
            forFind.Clear();
            bool isvalid = false;
            for (int i = 0; i < ((UserWindow)this.Owner).accounts.Count; i++)
            {
                isvalid = false;
                if(SearchByLogin.IsChecked == true)
                {
                    if (SearchedLogin.Text == ((UserWindow)this.Owner).accounts[i].Login)
                    {
                        isvalid = true;
                    }
                    else
                    {
                        isvalid = false;
                        continue;
                    }
                }
                if (SearchByPassword.IsChecked == true)
                {
                    if (SearchedPassword.Text == ((UserWindow)this.Owner).accounts[i].Password)
                    {
                        isvalid = true;
                    }
                    else
                    {
                        isvalid = false;
                        continue;
                    }
                }
                if (SearchBySiteName.IsChecked == true)
                {
                    if (SearchedSiteName.Text == ((UserWindow)this.Owner).accounts[i].SiteName)
                    {
                        isvalid = true;
                    }
                    else
                    {
                        isvalid = false;
                        continue;
                    }
                }
                if (SearchByLink.IsChecked == true)
                {
                    if (SearchedLink.Text == ((UserWindow)this.Owner).accounts[i].Link)
                    {
                        isvalid = true;
                    }
                    else
                    {
                        isvalid = false;
                        continue;
                    }
                }
                if (SearchinDescription.IsChecked == true)
                {
                    string desc_from_list = ((UserWindow)this.Owner).accounts[i].Description;
                    string[] arr_fromtextbox = SearchedDesc.Text.Split(new char[] { ' ' });
                    string[] arr_fromdesc = desc_from_list.Split(new char[] { ' ' });
                    for (int z = 0; z < arr_fromdesc.Length; z++)
                        this.Title += arr_fromdesc[z];
                    bool allfind = false;
                    for (int j = 0; j < arr_fromtextbox.Length; j++)
                    {
                        for (int k = 0; k < arr_fromdesc.Length; k++)
                        {
                            if (arr_fromdesc[k] == arr_fromtextbox[j])
                            {
                                allfind = true;
                                break;
                            }
                        }
                        if (allfind == false)
                        {
                            isvalid = false;
                            break;
                        }
                    }
                    if (allfind == true)
                        isvalid = true;
                    else if (isvalid == false)
                        continue;
                }
                if (isvalid == true)
                    forFind.Add(((UserWindow)this.Owner).accounts[i]);


            }
            GridOFFindedaccounts.Items.Refresh();

        }
        private void StartSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchAcc();
        }

        private void ClearBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            forFind.Clear();
            GridOFFindedaccounts.Items.Refresh();
        }
    }

}
