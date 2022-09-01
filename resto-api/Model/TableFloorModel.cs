using MongoDB.Bson;
using Realms;
namespace resto_api.Modal
{
public class TableFloorModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string? FloorName { get; set; }
    public IList<TableModel>? Tables { get; }

}
}