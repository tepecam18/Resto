using MongoDB.Bson;
using Realms;

public class DeviceModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string? MachineGuid { get; set; }
    public string? MachineName { get; set; }
    public bool IsActive { get; set; }


    [Ignored]
    public string? Token { get; set; }
    [Ignored]
    public string? PrivateKey { get; set; }

    [Ignored]
    public UsersModel? User { get; set; }
}
