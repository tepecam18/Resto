using System;
using System.Collections.Generic;

namespace RestoWPF.MVVM.Model
{
    public class OrderProductModel
    {
        public Decimal Price { get; set; }
        public decimal Piece { get; set; }
        public bool IsPrinted { get; set; }
        public ProductModel Product { get; set; }
        public IList<OrderOptionModel> OrderOptions { get; }
        public IList<StockUsageModel> StockUsages { get; }

        public Decimal TotalPrice { get; set; }

    }
}
