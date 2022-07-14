﻿using Realms;
using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.ViewModel
{
    public class TablesViewModel : ViewModelBase
    {
        #region parameter
        Realm realm = Realm.GetInstance(new ConstantRealmConfig());

        public List<TableModel> TablesLayer { get; set; }
        private TableModel _SelectedTablesLayer { get; set; }
        #endregion

        #region methods
        public TablesViewModel()
        {
            TablesLayer = realm.All<TableModel>().OrderBy(i => i.ID).ToList();
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
