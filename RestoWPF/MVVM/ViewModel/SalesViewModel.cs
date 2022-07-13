using Realms;
using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using RestoWPF.MVVM.View;
using RestoWPF.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RestoWPF.MVVM.ViewModel
{

    public class SalesViewModel : ViewModelBase
    {
        #region Data
        Realm realm = St.realm;

        public DailyModel Today { get => St.Today; }
        public IList<ProductGroupModel> ProductGroupList { get; set; }
        public IList<ProductModel> ProductList { get; set; }
        public OrderProductModel SelectedOrderProduct { get; set; }

        public AnotherCommandImplementation OrderCancelCommand { get; }
        public AnotherCommandImplementation SendOrderCommand { get; }
        public AnotherCommandImplementation NewOrderCommand { get; }
        public AnotherCommandImplementation ChangeOrderTabCommand { get; }
        public AnotherCommandImplementation OpenDialogCommand { get; }

        public int OrderTabIndex { get; set; }
        private NumberDialog? _Content;
        private bool _isDialogOpen;
        #endregion

        #region Ctor
        public SalesViewModel()
        {
            ProductGroupList = realm.All<ProductGroupModel>().OrderBy(i => i.Location).ToList();
            realm.Write(() =>
            {
                ProductList = ProductGroupList[0].Products;
                
                //Order = new OrderModel();

            });

            OrderCancelCommand = new AnotherCommandImplementation(OrderCancel);
            SendOrderCommand = new AnotherCommandImplementation(SendOrder);
            NewOrderCommand = new AnotherCommandImplementation(NewOrder);
            ChangeOrderTabCommand = new AnotherCommandImplementation(ChangeOrderTab);
            OpenDialogCommand = new AnotherCommandImplementation(OpenDialog);
        }
        #endregion

        #region Properties
        public OrderModel Order
        {
            get => St.Order;
            set => SetProperty(ref St.Order, value);
        }
        public ProductGroupModel SelectedProductGroup
        {
            set
            {
                if (value != null)
                {
                    ProductList = value.Products;
                    OnPropertyChanged("ProductList");
                }
            }
        }
        public ProductModel SelectedProductItem
        {
            set
            {
                if (value != null)
                {
                    //Ürün önceden eklendiyse adet arttır
                    int a = Order.Products.Where(i => i.Product.Id == value.Id).Count();
                    realm.Write(() =>
                    {
                        if (a > 0)
                        {
                            SelectedOrderProduct = Order.Products.Where(i => i.Product.Id == value.Id).First();
                            SelectedOrderProduct.Piece++;
                        }
                        else
                        {
                            SelectedOrderProduct = new OrderProductModel()
                            {
                                Product = value,
                                Piece = 1,
                                Price = value.Price,
                            };

                            Order.Products.Add(SelectedOrderProduct);
                        }

                        //totalPrice calculation and Trimming 0's
                        SelectedOrderProduct.TotalPrice = Convert.ToDecimal((Convert.ToDecimal(SelectedOrderProduct.Price) * SelectedOrderProduct.Piece).ToString("0.##"));
                    });
                }

                OnPropertyChanged("Order");
                //If the 2nd order tab is active
                OnPropertyChanged("SelectedOrderProduct");
                OnPropertyChanged("SelectedOrderProductPiece");
            }
        }
        public OrderProductModel SelectedOrderTab
        {
            set
            {
                if (value != null)
                {
                    OrderTabIndex = (OrderTabIndex == 0) ? 1 : 0;
                    realm.Write(() =>
                    {
                        SelectedOrderProduct = value;
                    });
                }

                OnPropertyChanged("OrderTabIndex");
                OnPropertyChanged("SelectedOrderProduct");
                OnPropertyChanged("SelectedOrderProductPiece");
            }
        }
        public decimal SelectedOrderProductPiece
        {
            get
            {
                if (SelectedOrderProduct is not null)
                {
                    return SelectedOrderProduct.Piece;
                }
                return 0;
            }
            set
            {
                if (value > 0)
                {
                    realm.Write(() =>
                    {
                        SelectedOrderProduct.Piece = value;
                        //totalPrice calculation and Trimming 0's
                        SelectedOrderProduct.TotalPrice = Convert.ToDecimal((Convert.ToDecimal(SelectedOrderProduct.Price) * SelectedOrderProduct.Piece).ToString("0.##"));
                    });

                    OnPropertyChanged("SelectedOrderProduct");
                    OnPropertyChanged("Order");
                }
            }
        }
        public bool IsDialogOpen
        {
            get => _isDialogOpen;
            set
            {
                if (value)
                {
                    SetProperty(ref _isDialogOpen, value);
                }
                else
                {
                    if (Content is not null)
                        SelectedOrderProductPiece = Content.Piece;
                    _isDialogOpen = false;
                    OnPropertyChanged();
                    OnPropertyChanged("SelectedOrderProductPiece");
                    OnPropertyChanged("SelectedOrderProduct");
                    OnPropertyChanged("Order");
                }
            }
        }
        public NumberDialog? Content
        {
            get => _Content;
            set => SetProperty(ref _Content, value);
        }
        #endregion

        #region Command
        private void OrderCancel(object obj)
        {
            //ProductOrder = new ObservableCollection<OrderProductModel>();
            OnPropertyChanged("Order");
        }

        private void SendOrder(object obj)
        {
        }

        private void NewOrder(object obj)
        {
            realm.Write(() =>
            {
                Order = new OrderModel();
                Today.Orders.Add(Order);
                OnPropertyChanged("Order");
            });
        }

        private void ChangeOrderTab(object obj)
        {
            OrderTabIndex = (OrderTabIndex == 0) ? 1 : 0;
            OnPropertyChanged("OrderTabIndex");
            OnPropertyChanged("Order");
        }

        private void OpenDialog(object obj)
        {
            Content = new NumberDialog();
            IsDialogOpen = true;
        }
        #endregion
    }
}
