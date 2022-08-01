﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class ProductOptionModel 
    {
        public string ID { get; set; }
        public string? OptionName { get; set; }
        public IList<ProductModel>? Products { get;}
    }
}
    