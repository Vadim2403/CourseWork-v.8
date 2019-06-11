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
            ((UserWindow)this.Owner).accounts.Add(new Account { Login = Login.Text, Description = desc, Link = Link.Text, Password = Password.Text, SiteName = SiteName.Text });
            ((UserWindow)this.Owner).GridOFaccounts.Items.Refresh();
            this.Close();
        }

        private void NeedDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            DescriptionWindow descriptionWindow = new DescriptionWindow();
            descriptionWindow.Owner = this;
            descriptionWindow.DescText.Text = desc;
            descriptionWindow.Show();
        }
    }
}
