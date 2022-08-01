﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class OrderProductModel
    {
        public decimal Price { get; set; }
        public decimal Piece { get; set; }
        public bool IsPrinted { get; set; }
        public ProductModel Product { get; set; }
        public IList<OrderOptionModel> OrderOptions { get; }
        public IList<StockUsageModel> StockUsages { get;}

        public decimal TotalPrice { get; set; }

    }
}
