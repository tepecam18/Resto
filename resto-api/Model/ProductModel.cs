using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class ProductModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? Name { get; set; }
        [MapTo("Price")]
        public Decimal128 Price { get; set; }
        public int Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsShow { get; set; }
        public CostumeThemeModel? CostumeTheme { get; set; }
        public IList<ProductOptionModel>? ProductOptions { get; }
        public IList<StockUseModel>? stockUses { get; }
    }
}
