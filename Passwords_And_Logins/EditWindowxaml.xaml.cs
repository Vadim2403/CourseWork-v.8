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
            acc.Login = Login.Text;
            acc.Password = Password.Text;
            acc.Description = Description_for_nextWindow;
            ((UserWindow)this.Owner).GridOFaccounts.Items.Refresh();
            this.Close();
        }

        private void NeedDescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            DescriptionWindow descriptionWindow = new DescriptionWindow();
            descriptionWindow.Owner = this;
            descriptionWindow.Show();
        }
    }
}
