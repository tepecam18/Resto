using MongoDB.Bson;
using Realms;

public class ProductGroupModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string? GroupName { get; set; }
    public bool IsActive { get; set; }
    public int Location { get; set; }

    public IList<ProductModel> Products { get; }
}