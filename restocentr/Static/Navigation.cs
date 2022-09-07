using restocentr.Core;
using restocentr.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace restocentr.Static
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
            yield return new RestoItem(typeof(LoginView), 0);

            Nv.MainMenu = i++;
            yield return new RestoItem(typeof(MainView));

            Nv.Sales = i++;
            yield return new RestoItem(typeof(SalesView), 2);

            Nv.Tables = i++;
            yield return new RestoItem(typeof(TablesView));

            Nv.Orders = i++;
            yield return new RestoItem(typeof(OrdersView));
        }

        private static void ClearAll()
        {
            ClearBack();

            RestoItems.Clear();
            foreach (var item in GenerateRestoItem())
            {
                RestoItems.Add(item);
            }
        }
        public static void ClearBack()
        {
            BackList.Clear();
            BackList.Add(0);
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

        internal static void GetBack(bool IsCache = true)
        {
            //todo oturum kapattıgında viewları temizle kontrol edilecek
            BackList.Remove(BackList.Last());
            if (BackList.Last() > 0)
            {
                RestoItems[BackList.Last()].IsCache = IsCache;
                MainWindow.viewModel.SelectedItem = RestoItems[BackList.Last()];
            }
            else
            {
                MainWindow.viewModel.SelectedItem = RestoItems[0];
                ClearBack();
            }
        }
        #endregion
    }
}
