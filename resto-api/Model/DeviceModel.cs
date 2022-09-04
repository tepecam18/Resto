using MongoDB.Bson;
using Realms;
namespace resto_api.Modal
{
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

    [Ignored]
    public UsersModel? User { get; set; }

    [Ignored]
    public int WarningCount { get; set; } = 0;
}
}