using restocentr.Core;
using restocentr.Model;
using System.Collections.Generic;

namespace restocentr.Component.Dialog
{
    internal class CanceledDialogModel : ViewModelBase
    {
        public List<CanceledModel> Canceleds { get; set; }
        public CanceledModel SelectedCanceled { get; set; }
        public string SelectedText { get; set; }
        public bool SelectedIsFavorite { get; set; }
        public CanceledDialogModel()
        {
            //Canceleds = St.realm.All<CanceledModel>().Where(i=> i.IsFavorite).ToList();
        }
    }
}
