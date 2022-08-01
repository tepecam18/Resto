using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.Model
{
    public class StockModel : EmbeddedObject
    {
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public Decimal128 Price{ get; set; }
        public Decimal128 Amount { get; set; }
    }
}
