using MongoDB.Bson;
using restocentr.Static;
using System;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class OrderModel
    {

        public ObjectId ID { get; set; }
        public DateTimeOffset DateT { get; set; } = DateTime.Now;
        public string OrderNote { get; set; } = "";
        public bool IsClosed { get; set; }
        public bool IsCanceled { get; set; }
        public CanceledModel Canceled { get; set; }
        public TableModel Tables { get; set; }
        public DeviceModel Device { get; set; } = St.Device;
        public UsersModel CourierPerson { get; set; }
        public UsersModel SalesPerson { get; set; } = St.User;
        public IList<OrderProductModel> Products { get; }
        public IList<PaymentModel> Payments { get; }


        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                if (Products is not null)
                {
                    foreach (OrderProductModel order in Products)
                    {
                        total += Convert.ToDecimal(order.TotalPrice);
                    }
                }
                return total;
            }
        }
    }
}
