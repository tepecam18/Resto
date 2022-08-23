using MongoDB.Bson;
using Realms;

public class CostumeThemeModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string Color { get; set; }
    public bool IsDefault { get; set; }
}