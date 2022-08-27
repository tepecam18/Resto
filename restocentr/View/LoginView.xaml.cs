using restocentr.Model;
using restocentr.Static;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace restocentr.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }
        #region Login


        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            txPassword.Password += ((Button)sender).Content;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txPassword.Password = "";
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs? e)
        {
            if (txPassword.Password != "")
            {
                await Hub.UserLogin(txPassword.Password);
            }
            else
            {
                //todo bottom bildirim
            }

            if (txPassword.Password == "ptts1")
            {
                //Hile kodları
            }

            txPassword.Password = "";
        }

        private void txPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(BtnLogin, null);
            }
        }


        #endregion

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            txPassword.Focus();
        }
    }
}
