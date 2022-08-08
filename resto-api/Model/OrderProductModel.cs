using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class OrderProductModel : EmbeddedObject
    {
        public Decimal128 Price { get; set; }
        public decimal Piece { get; set; }
        public bool IsPrinted { get; set; }
        public ProductModel Product { get; set; }
        public IList<OrderOptionModel> OrderOptions { get; }
        public IList<StockUsageModel> StockUsages { get; }

        [BsonIgnore]
        public Decimal128 TotalPrice { get; set; }

    }
}
