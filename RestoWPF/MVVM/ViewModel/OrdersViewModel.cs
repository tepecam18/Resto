using Realms;
using RestoWPF.Core;
using RestoWPF.MVVM.Model;
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
        Realm realm = Realm.GetInstance(new ConstantRealmConfig());
        public DateTime _Date { get; set; } = DateTime.Now.Date;

        public DailyModel Today { get; set; }

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
    }
}
