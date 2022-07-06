using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class DeviceModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}