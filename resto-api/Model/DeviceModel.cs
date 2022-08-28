using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;

public class DeviceModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string? MachineGuid { get; set; }
    public string? MachineName { get; set; }
    public bool IsActive { get; set; }
    public string? Token { get; set; }
    public string? PrivateKey { get; set; }
    public string? ConnectionId { get; set; }

    [BsonIgnore]
    public UsersModel? User { get; set; }

    [BsonIgnore]
    public int WarningCount { get; set; } = 0;
}
