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
        public IList<OrderOptionModel> OrderOptions { get; set; }
        public IList<StockUsageModel> StockUsages { get; set; }

        public Decimal128 TotalPrice { get; set; }

    }
}
