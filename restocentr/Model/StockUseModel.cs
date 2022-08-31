using System;

namespace restocentr.Model
{
    public class StockUseModel
    {
        public string ID { get; set; }
        public StockProductModel StockProduct { get; set; }
        public Decimal Amount { get; set; }
    }
}
