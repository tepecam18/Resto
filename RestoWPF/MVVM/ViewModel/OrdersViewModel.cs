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
        public DateTime _Date { get; set; } = DateTime.Now.Date;
        public DailyModel Today { get; set; } = St.Today;

        private DateTime _date;
        private DateTime _time;
        private string? _validatingTime;
        private DateTime? _futureValidatingDate;
        #endregion

        #region Ctor
        public OrdersViewModel()
        {
            Date = DateTime.Now;
            Time = DateTime.Now;
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
                else if (realm.All<DailyModel>().Where(i => i.Date == _Date).Count() > 0)
                {
                    Today = realm.All<DailyModel>().Single(i => i.Date == _Date);
                }
                else
                {
                    MessageBox.Show("Geçersiz Tarih");
                }
                OnPropertyChanged();
                OnPropertyChanged("Today");
            }
        }
        public OrderModel SelectedOrder
        {
            set
            {
                if (value is not null)
                {
                    St.Order = value;
                    //Nv.GetBack(false);
                }
            }
        }
        #endregion


        #region picker



        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public DateTime Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        public string? ValidatingTime
        {
            get => _validatingTime;
            set => SetProperty(ref _validatingTime, value);
        }

        public DateTime? FutureValidatingDate
        {
            get => _futureValidatingDate;
            set => SetProperty(ref _futureValidatingDate, value);
        }

        #endregion
    }
}
