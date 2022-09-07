using MaterialDesignThemes.Wpf;
using restocentr.Component.Dialog;
using restocentr.Core;
using restocentr.Model;
using restocentr.Static;
using System;
using System.Windows;

namespace restocentr.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        #region Data
        private DateTime _Date { get; set; } = DateTime.Now.Date;
        public OrderModel _SelectedOrder { get; set; }
        public DailyModel Today { get; set; } = St.Today;

        public AnotherCommandImplementation ShowSalesCommand { get; }
        public AnotherCommandImplementation CanceledSalesCommand { get; }
        public AnotherCommandImplementation DetailSalesCommand { get; }
        #endregion

        #region Ctor
        public OrdersViewModel()
        {
            ShowSalesCommand = new AnotherCommandImplementation(ShowSales);
            CanceledSalesCommand = new AnotherCommandImplementation(CanceledSales);
            DetailSalesCommand = new AnotherCommandImplementation(DetailSales);
        }
        #endregion

        #region Properties
        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                //_Date = value.Date;
                //if (realm.All<DailyModel>().Where(i => i.Date == _Date).Count() > 1) //bugünü başlat
                //{
                //    Today = realm.All<DailyModel>().Where(i => i.Date == _Date).First();
                //}
                //else
                //{
                //    MessageBox.Show("Geçerli Güne Ait veriler bulunamadı");
                //}
                //OnPropertyChanged();
                //OnPropertyChanged("Today");
            }
        }
        public OrderModel SelectedOrder
        {
            get => _SelectedOrder;
            set
            {
                if (value is not null)
                {
                    _SelectedOrder = value;
                    OnPropertyChanged();
                    OnPropertyChanged("SelectedOrderIsCanceled");
                    OnPropertyChanged("SelectedOrderIsClosed");
                }
            }
        }
        public bool SelectedOrderIsCanceled
        {
            get
            {
                if (_SelectedOrder is not null)
                {
                    return !_SelectedOrder.IsCanceled;
                }
                return true;
            }
        }
        public bool SelectedOrderIsClosed
        {
            get
            {
                if (_SelectedOrder is not null)
                {
                    return !(_SelectedOrder.IsCanceled || _SelectedOrder.IsClosed);
                }
                return true;
            }
        }
        #endregion

        #region Command
        private void ShowSales(object obj)
        {
            if (SelectedOrder is not null)
            {
                St.Order = SelectedOrder;
                //todo daha iyisini yapana kadar en iyisi bu
                Nv.GetBack(false);
            }
            else
            {
                MessageBox.Show("Neyi", "Uyarı");
            }
        }
        private async void CanceledSales(object obj)
        {
            //Ürün Seçili mi
            if (SelectedOrder is not null)
            {
                CanceledDialog view = new CanceledDialog()
                {
                    DataContext = new CanceledDialogModel()
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
                if (result is bool)
                {
                    //Onaylandı mı
                    if (Convert.ToBoolean(result))
                    {
                        CanceledModel canceled = ((CanceledDialogModel)view.DataContext).SelectedCanceled;

                        string canceledstr = ((CanceledDialogModel)view.DataContext).SelectedText;

                        bool canceledIsFavorite = ((CanceledDialogModel)view.DataContext).SelectedIsFavorite;

                        //Veri Kayıtlı  değilse kaydet
                        if (canceled is not null) { }
                        else if (canceledstr is not null)
                        {
                            canceled = new CanceledModel()
                            {
                                Note= canceledstr,
                                IsFavorite = canceledIsFavorite
                            };
                        }
                        else
                        {
                            return;
                        }

                        SelectedOrder.Canceled = canceled;
                        SelectedOrder.IsCanceled = true;

                    }
                }
                else
                {
                    MessageBox.Show("Hatalı veya Eksik Veri Girişi Yapıldı", "Hata");
                }
            }
            else
            {
                MessageBox.Show("Neyi", "Uyarı");
            }
            OnPropertyChanged("Today");
        }
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs) { }

        private void DetailSales(object obj)
        {
            if (SelectedOrder is not null)
            {
                OrderDetailDialog view = new OrderDetailDialog()
                {
                    //DataContext = new OrderDetailDialogModel()
                };

                DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
            else
            {
                MessageBox.Show("Neyi", "Uyarı");
            }
        }
        #endregion
    }
}
