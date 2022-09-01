using MongoDB.Bson;
using Realms;
namespace resto_api.Modal
{
    public class StockUseModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public StockProductModel? StockProduct { get; set; }
    public Decimal128 Amount { get; set; }
}
}