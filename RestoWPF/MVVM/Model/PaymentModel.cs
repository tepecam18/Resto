using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class PaymentModel : EmbeddedObject
    {
        public PaymentTypeModel Type { get; set; }
        public Decimal128 Price { get; set; }
    }
}
