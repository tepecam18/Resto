using MongoDB.Bson;
using System;

namespace restocentr.Model
{
    public class PaymentModel
    {
        public PaymentTypeModel Type { get; set; }
        public Decimal Price { get; set; }
    }

    public class PaymentTypeModel
    {
        public ObjectId ID { get; set; }
        public string Name { get; set; }
    }
}
