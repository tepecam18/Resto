using MongoDB.Bson;
using Realms;

public class ProductOptionModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string? OptionName { get; set; }
    public IList<ProductModel>? Products { get; }
}