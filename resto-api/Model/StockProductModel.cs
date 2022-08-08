using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class StockProductModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string Name { get; set; } = "";
        public string Unit { get; set; }
        public IList<StockModel> Stocks { get; }
    }
}
