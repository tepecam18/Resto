using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class PaymentModel
    {
        public PaymentTypeModel Type { get; set; }
        public decimal Price { get; set; }
    }

    public class PaymentTypeModel 
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
