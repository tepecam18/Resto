using Microsoft.Win32;
using RestoWPF.MVVM.Model;
using RestoWPF.Static;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RestoWPF.MVVM.View
{
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

        private void LoginButton_Click(object sender, RoutedEventArgs? e)
        {
            if (txPassword.Password != "")
            {
                //UsersModel user = (UsersModel)realm.All<UsersModel>().Where(i => i.Password == txPassword.Password && i.IsActive).FirstOrDefault();
                UsersModel user = new UsersModel();
                if (user != null)
                {
                    if (St.User == user)
                    {
                        Nv.GetBack();
                    }
                    else
                    {
                        St.User = user;
                        Nv.SetContent(Nv.MainMenu);
                    }
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
