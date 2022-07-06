using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class OrderProductModel : EmbeddedObject
    {
        public ProductModel? Product { get; set; }
        public Decimal128 Price { get; set; }
        public decimal Piece { get; set; }
        [BsonIgnore]
        public Decimal128 TotalPrice { get; set; }
        [BsonIgnore]
        public bool IsPrinted { get; set; }

    }
}
