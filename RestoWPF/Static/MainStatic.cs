using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.Static
{
    internal static class St
    {
        //public static Realm realm; todo
        public static DailyModel Today;
        public static OrderModel Order = new OrderModel();
        internal static UsersModel User { get; set; }
        internal static DeviceModel Device { get; set; }

        #region Ctor
        static St()
        {
            //realm = Realm.GetInstance(new ConstantRealmConfig()); todo
            //todo Device Kaydedici
            //if (realm.All<DeviceModel>().Count() > 0)
            //{
            //    Device = realm.All<DeviceModel>().First();
            //} todo
            //todo if ana makine mi
            //realm.Write(() => todo
            //{
            //    DateTimeOffset Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
            //    //Bugünün verisini al yoksa oluştur
            //    if (realm.All<DailyModel>().Where(i => i.Date == Date).Count() >= 1)
            //    {
            //        Today = realm.All<DailyModel>().Where(i => i.Date == Date).First();
            //    }
            //    else
            //    {
            //        Today = realm.Add(new DailyModel());
            //    }
            //});
        }
        #endregion
    }
}
