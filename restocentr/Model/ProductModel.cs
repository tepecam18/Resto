using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class ProductModel
    {
        public ObjectId ID { get; set; }
        public string Name { get; set; }
        public Decimal128 Price { get; set; }
        public int Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsShow { get; set; }
        public CostumeThemeModel CostumeTheme { get; set; }
        public IList<ProductOptionModel> ProductOptions { get; }
        public IList<StockUseModel> stockUses { get; }
    }
}
