

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class StockUseModel
    {
        public string ID { get; set; }
        public StockProductModel? StockProduct{ get; set; }
        public decimal Amount { get; set; }
    }
}
