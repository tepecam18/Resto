using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.Model
{
    public class PaymentModel : EmbeddedObject
    {
        public PaymentTypeModel Type { get; set; }
        public Decimal128 Price { get; set; }
    }

    public class PaymentTypeModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string Name { get; set; }
    }
}
