using MongoDB.Bson;
using Realms;

namespace resto_api.Modal
{
    public class CanceledModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string Note { get; set; } = "";
    public bool IsFavorite { get; set; }
}
}