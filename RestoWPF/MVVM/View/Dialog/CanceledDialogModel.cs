using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using RestoWPF.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.View.Dialog
{
    internal class CanceledDialogModel : ViewModelBase
    {
        public List<CanceledModel> Canceleds { get; set; }
        public CanceledModel SelectedCanceled { get; set; }
        public string SelectedText { get; set; }
        public bool SelectedIsFavorite { get; set; }
        public CanceledDialogModel()
        {
            Canceleds = St.realm.All<CanceledModel>().Where(i=> i.IsFavorite).ToList();
        }
    }
}
