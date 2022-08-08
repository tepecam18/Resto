using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class ProductOptionModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? OptionName { get; set; }
        public IList<ProductModel>? Products { get; }
    }
}
