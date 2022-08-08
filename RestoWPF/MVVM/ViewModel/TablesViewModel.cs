using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using System.Collections.Generic;

namespace RestoWPF.MVVM.ViewModel
{
    public class TablesViewModel : ViewModelBase
    {
        #region parameter

        public List<TableModel> TablesLayer { get; set; }
        private TableModel _SelectedTablesLayer { get; set; }
        #endregion

        #region methods
        public TablesViewModel()
        {
            //TablesLayer = realm.All<TableModel>().OrderBy(i => i.ID).ToList();
            _SelectedTablesLayer = TablesLayer[0];
        }
        #endregion

        public TableModel SelectedTablesLayer
        {
            get { return _SelectedTablesLayer; }
            set
            {
                if (value != null)
                {
                    _SelectedTablesLayer = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
