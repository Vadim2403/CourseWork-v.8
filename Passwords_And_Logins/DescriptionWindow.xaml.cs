using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Passwords_And_Logins
{
    /// <summary>
    /// Логика взаимодействия для DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {
        
        public DescriptionWindow()
        {
            InitializeComponent();
 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Owner.GetType() == typeof(EditWindowxaml))
            {
                EditWindowxaml ew = (EditWindowxaml)this.Owner;
                DescText.Text = ew.Description_for_nextWindow;
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.Owner.GetType() == typeof(AddWindow))
            {
                ((AddWindow)this.Owner).desc = DescText.Text;
            }
            else
                ((EditWindowxaml)this.Owner).Description_for_nextWindow = DescText.Text;

            this.Close();
        }
    }
}
