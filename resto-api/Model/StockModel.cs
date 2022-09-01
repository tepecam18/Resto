using MongoDB.Bson;
using Realms;
namespace resto_api.Modal
{
    public class StockModel : EmbeddedObject
{
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public Decimal128 Price { get; set; }
    public Decimal128 Amount { get; set; }
}
}