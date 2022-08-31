using System;

namespace restocentr.Model
{
    public class StockUsageModel
    {
        public string ID { get; set; }
        public StockProductModel StockProduct { get; set; }
        public Decimal Amount { get; set; }
    }
}
