using System;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class ProductModel
    {
        public string ID { get; set; }
        public string? Name { get; set; }
        public Decimal Price { get; set; }
        public int Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsShow { get; set; }
        public CostumeThemeModel? CostumeTheme { get; set; }
        public IList<ProductOptionModel>? ProductOptions { get; }
        public IList<StockUseModel>? stockUses { get; }
    }
}
