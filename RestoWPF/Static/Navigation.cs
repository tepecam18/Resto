using RestoWPF.Core;
using RestoWPF.MVVM.Model;
using RestoWPF.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.Static
{
    internal static class Nv
    {
        #region Data
        public static ObservableCollection<RestoItem> RestoItems { get; }
        private static List<int> BackList { get; set; } = new List<int>() { 0 };
        //viewvler
        internal static int Login { get; set; }
        internal static int MainMenu { get; set; }
        internal static int Sales { get; set; }
        internal static int Tables { get; set; }
        internal static int Orders { get; set; }
        internal static int blank { get; set; }
        internal static int blank2 { get; set; }
        #endregion

        #region Ctor
        static Nv()
        {
            RestoItems = new ObservableCollection<RestoItem>();
            foreach (var item in GenerateRestoItem())
            {
                RestoItems.Add(item);
            }
        }
        #endregion

        #region Properties
        private static IEnumerable<RestoItem> GenerateRestoItem()
        {
            int i = 0;

            Nv.Login = i++;
            yield return new RestoItem(typeof(LoginView));

            Nv.MainMenu = i++;
            yield return new RestoItem(typeof(MainMenuView));

            Nv.Sales = i++;
            yield return new RestoItem(typeof(SalesView));

            Nv.Tables = i++;
            yield return new RestoItem(typeof(TablesView));

            Nv.Orders = i++;
            yield return new RestoItem(typeof(OrdersView));
        }
        #endregion

        #region Methods
        /// <summary>
        /// NAvigation aracı
        /// </summary>
        /// <param name="index">Nv.ViewAdı</param>
        internal static void SetContent(int index, bool IsCache = true)
        {
            BackList.Add(index);
            RestoItems[index].IsCache = IsCache;
            MainWindow.viewModel.SelectedItem = RestoItems[index];
        }

        internal static void GetBack()
        {
            BackList.Remove(BackList.Last());
            //BackList her zaman en az 1 değeri olmalı
            if (BackList.Last() > 1)
            {
                MainWindow.viewModel.SelectedItem = RestoItems[BackList.Last()];
                MainWindow.viewModel.SelectedIndex=1;
            }
            else
            {
                MainWindow.viewModel.SelectedItem = RestoItems[0];
                MainWindow.viewModel.SelectedIndex=0;
                BackList.Clear();
            }
        }
        #endregion
    }
}
