using Realms;
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
        public static Realm realm;
        public static DailyModel Today;
        public static OrderModel Order;
        internal static UsersModel User { get; set; }

        #region Ctor
        static St()
        {
            realm = Realm.GetInstance(new ConstantRealmConfig());
            //todo if ana makine mi
            realm.Write(() =>
            {
                if (realm.All<DailyModel>().Where(i => i.Date == DateTime.Now.Date).Count() > 1)
                {
                    Today = realm.All<DailyModel>().Where(i => i.Date == DateTime.Now.Date).First();
                }
                else
                {
                    Today = realm.Add(new DailyModel());
                }

                if (Today.Orders.Count > 0)
                {
                    Order = Today.Orders.First();
                }
                else
                {
                    Order = new OrderModel();
                    Today.Orders.Add(Order);
                }
            });
        }
        #endregion
    }
}
