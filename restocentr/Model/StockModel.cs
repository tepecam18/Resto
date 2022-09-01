using MongoDB.Bson;
using System;

namespace restocentr.Model
{
    public class StockModel
    {
        public ObjectId ID { get; set; }
        public Decimal Price { get; set; }
        public Decimal Amount { get; set; }
    }
}
