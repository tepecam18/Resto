using MongoDB.Bson;
using System;

namespace restocentr.Model
{
    public class StockUseModel
    {
        public string ObjectId { get; set; }
        public StockProductModel StockProduct { get; set; }
        public Decimal128 Amount { get; set; }
    }
}
