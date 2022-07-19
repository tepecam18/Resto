using Realms;
using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using RestoWPF.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestoWPF.MVVM.ViewModel
{
    internal class OrdersViewModel : ViewModelBase
    {
        #region Data
        Realm realm = St.realm;
        private DateTime _Date { get; set; } = DateTime.Now.Date;
        public OrderModel SelectedOrder { get; set; }
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
                _Date = value.Date;
                if (realm.All<DailyModel>().Where(i => i.Date == _Date).Count() > 1) //bugünü başlat
                {
                    Today = realm.All<DailyModel>().Where(i => i.Date == _Date).First();
                }
                else
                {
                    MessageBox.Show("Geçerli Güne Ait veriler bulunamadı");
                }
                OnPropertyChanged();
                OnPropertyChanged("Today");
            }
        }
        #endregion

        #region Command
        private void ShowSales(object obj)
        {
            if (SelectedOrder is not null)
            {
                St.Order = SelectedOrder;
                Nv.GetBack(false);
            }
            else
            {
                MessageBox.Show("Neyi", "Uyarı");
            }
        }
        private void CanceledSales(object obj)
        {
            realm.Write(() =>
            {
                //todo Canceled note ekle
                SelectedOrder.IsCanceled = true;
            });
        }
        private void DetailSales(object obj)
        {
            //todo detay göster
        }
        #endregion
    }
}
