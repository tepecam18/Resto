using MongoDB.Bson;
using Realms;

public class StockUseModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public StockProductModel? StockProduct { get; set; }
    public Decimal128 Amount { get; set; }
}