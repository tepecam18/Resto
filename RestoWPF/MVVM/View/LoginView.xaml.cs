using ControlzEx.Theming;
using Realms;
using RestoWPF.Core;
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
        Realm realm;

        public LoginView()
        {
            InitializeComponent();
            try
            {
                realm = St.realm;
            }
            catch (Exception)
            {
                MessageBox.Show("LoginView error realm");
            }
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
                UsersModel user = (UsersModel)realm.All<UsersModel>().Where(i => i.Password == txPassword.Password && i.IsActive).FirstOrDefault();
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

                    realm.Write(() =>
                    {
                        CostumeThemeModel costumeTheme = realm.Add(new CostumeThemeModel()
                        {
                            Color = "#FFFF0000",
                        });

                        realm.Add(new UsersModel()
                        {
                            UserName = "tpcm",
                            Password = "1",
                            IsActive = true,
                        });


                        for (int i = 0; i < 4; i++)
                        {
                            var TL = realm.Add(new TablesLayerModel()
                            {
                                LayerName = $"Kat: {i}",
                            });

                            for (int j = 0; j < 5*i; j++)
                            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                TL.Tables.Add(new TablesModel()
                                {
                                    TableName = $"Masa: {j}",
                                });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }
                        }

                        var PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Köfte",
                            IsActive = true,
                        });

                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });

                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Et",
                            IsActive = true,
                        });

                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Et yerim Menü 70gr",
                            Price = 90,
                            CostumeTheme = costumeTheme,
                        });

                        PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Tavuk",
                            IsActive = true,
                        });

                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 70gr",
                            Price = 90,
                        });

                        PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Hepsi Mi bir",
                            IsActive = true,
                        });

                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Et yerim Menü 70gr",
                            Price = 90.95M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Taavuk yerim Menü 80gr",
                            Price = 90.9999M,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 70gr",
                            Price = 90,
                        });

                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Et yerim Menü 70gr",
                            Price = 90.95M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Taavsuk yesrim Menü 80gr",
                            Price = 90.9999M,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Senis yserim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Senis yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Sensi yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Sensis yerim Menü 90gr",
                            Price = 90.99M,
                        });

                        var today = realm.Add(new DailyModel());

                        for (int j = 0; j < 1000; j++)
                        {
                            OrderModel b = new OrderModel();
                            foreach (var item in PG.Products)
                            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                b.Products.Add(new OrderProductModel()
                                {
                                    Product = item
                                });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                            today.Orders.Add(b);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        }

                        //todo sifreler haslanacak
                    });
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
