using restocentr.Component.Dialog;
using restocentr.Core;
using restocentr.Model;
using restocentr.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace restocentr.ViewModel
{
    class SalesViewModel : ViewModelBase
    {
        #region Data
        public IList<ProductGroupModel> ProductGroupList { get => St.ProductGroup; }
        public IList<ProductModel> ProductList { get; set; }
        public OrderProductModel SelectedOrderProduct { get; set; }

        public AnotherCommandImplementation OrderCancelCommand { get; }
        public AnotherCommandImplementation SendOrderCommand { get; }
        public AnotherCommandImplementation NewOrderCommand { get; }
        public AnotherCommandImplementation ChangeOrderTabCommand { get; }
        public AnotherCommandImplementation OpenDialogCommand { get; }

        public int OrderTabIndex { get; set; }
        private NumberDialog _Content;
        private bool _isDialogOpen;
        #endregion

        #region Ctor
        public SalesViewModel()
        {
            if (ProductGroupList is not null)
            {
                ProductList = ProductGroupList[0].Products;

                OrderCancelCommand = new AnotherCommandImplementation(CancelOrder);
                SendOrderCommand = new AnotherCommandImplementation(SendOrder);
                NewOrderCommand = new AnotherCommandImplementation(NewOrder);
                ChangeOrderTabCommand = new AnotherCommandImplementation(ChangeOrderTab);
                OpenDialogCommand = new AnotherCommandImplementation(OpenDialog);
            }
        }

        public void Change()
        {
            OnPropertyChanged("Order");
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
                if (value is not null)
                {
                    int a = 0;
                    if (Order.Products is not null)
                        a = Order.Products.Where(i => i.Product.ID == value.ID).Count();
                    else
                    {
                        Order.Products = new ObservableCollection<OrderProductModel>();
                    }
                    //Aynı üründen Sepette var mı
                    if (a > 0)
                    {
                        SelectedOrderProduct = Order.Products.Where(i => i.Product.ID == value.ID).First();
                        SelectedOrderProduct.Piece++;
                        //todo daha iyisini yapabilirsin(ObservableCollection değişiklikleri göstermiyor)
                        a = Order.Products.IndexOf(SelectedOrderProduct);
                        Order.Products.Remove(SelectedOrderProduct);
                        Order.Products.Insert(a, SelectedOrderProduct);
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
                    SelectedOrderProduct = value;
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
                    SelectedOrderProduct.Piece = value;
                    //totalPrice calculation and Trimming 0's
                    SelectedOrderProduct.TotalPrice = Convert.ToDecimal((Convert.ToDecimal(SelectedOrderProduct.Price) * SelectedOrderProduct.Piece).ToString("0.##"));

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
        public NumberDialog Content
        {
            get => _Content;
            set => SetProperty(ref _Content, value);
        }
        #endregion

        #region Command
        private void CancelOrder(object obj)
        {
            Nv.ClearBack();
            Nv.SetContent(Nv.MainMenu);
        }

        private void SendOrder(object obj)
        {
        }

        private void NewOrder(object obj)
        {
            Order = new OrderModel();
            OnPropertyChanged("Order");
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
