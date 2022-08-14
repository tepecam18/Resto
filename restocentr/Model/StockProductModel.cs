﻿using System.Collections.Generic;

namespace restocentr.Model
{
    public class StockProductModel
    {
        public string ID { get; set; }
        public string Name { get; set; } = "";
        public string Unit { get; set; }
        public IList<StockModel> Stocks { get; }
    }
}