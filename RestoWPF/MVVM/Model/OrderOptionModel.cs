﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class OrderOptionModel
    {
        public ProductOptionModel ProductOption { get; set; }
        public ProductModel Product { get; set; }
    }
}
