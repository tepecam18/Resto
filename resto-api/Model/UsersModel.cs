using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;

namespace resto_api.Model
{
    public class UsersModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int Auth { get; set; }
        public bool IsActive { get; set; }

    }
}

//realm.Write(() =>
//{
//    realm.Add(new UsersModel()
//    {
//        UserName = "test",
//        Password = "123"
//    });
//});