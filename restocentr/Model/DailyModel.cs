using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class DailyModel
    {
        public ObjectId ID { get; set; }
        public DateTimeOffset Date { get; set; }
        public IList<OrderModel> Orders { get; }
        public IList<StockModel> Stocks { get; }
    }
}
