using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
namespace resto_api.Modal
{
    public class DailyModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public DateTimeOffset Date { get; set; }
        [BsonElement]
        public IList<OrderModel> Orders { get; }
        [BsonElement]
        public IList<StockModel> Stocks { get; }

        public DailyModel()
        {
            Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
        }
    }
}