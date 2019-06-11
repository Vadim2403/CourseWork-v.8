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
        public EditWindowxaml()
        {
            InitializeComponent();
            UserWindow uw = (UserWindow)this.Owner;
            Login.Text = ((Account)uw.GridOFaccounts.SelectedItems[0]).Login;
            Password.Text = ((Account)uw.GridOFaccounts.SelectedItems[0]).Password;
            Description_for_nextWindow = ((Account)uw.GridOFaccounts.SelectedItems[0]).Description;
        }

        private void FinishAddingBtn_Click(object sender, RoutedEventArgs e)
        {
            UserWindow uw = (UserWindow)this.Owner;
            ((Account)uw.GridOFaccounts.SelectedItems[0]).Login = Login.Text;
            ((Account)uw.GridOFaccounts.SelectedItems[0]).Password = Password.Text;
            ((Account)uw.GridOFaccounts.SelectedItems[0]).Description = Description_for_nextWindow;
        }
    }
}
