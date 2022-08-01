﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class DailyModel 
    {
        public string ID { get; set; }
        public DateTimeOffset Date { get; set; }
        public IList<OrderModel> Orders { get; }
        public IList<StockModel> Stocks { get; }

        public DailyModel()
        {
            Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
        }
    }
}
