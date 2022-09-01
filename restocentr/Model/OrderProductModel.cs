using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class OrderProductModel
    {
        public Decimal128 Price { get; set; }
        public decimal Piece { get; set; }
        public bool IsPrinted { get; set; }
        public ProductModel Product { get; set; }
        public IList<OrderOptionModel> OrderOptions { get; }
        public IList<StockUsageModel> StockUsages { get; }

        public Decimal128 TotalPrice { get; set; }

    }
}
