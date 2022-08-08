using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class StockUsageModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public StockProductModel? StockProduct { get; set; }
        public Decimal128 Amount { get; set; }
    }
}
