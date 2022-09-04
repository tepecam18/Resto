using MongoDB.Bson;
using restocentr.Static;
using System;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class OrderModel
    {

        public ObjectId ID { get; set; }
        public DateTimeOffset DateT { get; set; }
        public string OrderNote { get; set; }
        public bool IsClosed { get; set; }
        public bool IsCanceled { get; set; }
        public CanceledModel Canceled { get; set; }
        public TableModel Tables { get; set; }
        public DeviceModel Device { get; set; }
        public UsersModel SalesPerson { get; set; }
        public UsersModel PaymantPerson { get; set; }
        public UsersModel WaiterPerson { get; set; }
        public IList<OrderProductModel> Products { get; set; }
        public IList<PaymentModel> Payments { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
