using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class OrderOptionModel : RealmObject
    {
        public ProductOptionModel ProductOption { get; set; }
        public ProductModel Product { get; set; }
    }
}
