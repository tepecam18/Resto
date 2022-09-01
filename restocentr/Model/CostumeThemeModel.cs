using MongoDB.Bson;

namespace restocentr.Model
{
    public class CostumeThemeModel
    {
        public ObjectId ID { get; set; }
        public string Color { get; set; }
        public bool IsDefault { get; set; }
    }
}
