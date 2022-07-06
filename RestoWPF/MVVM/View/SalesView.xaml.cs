using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using RestoWPF.Static;

namespace RestoWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for SatisView.xaml
    /// </summary>
    public partial class SalesView : UserControl
    {

        public SalesView()
        {
            InitializeComponent();
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e) { }

        private void TablesButton_Click(object sender, RoutedEventArgs e) =>
            Nv.SetContent(Nv.Tables);

        #region NUDSelectedOrderProductPiece Change
        private void CeyrekButton_Click(object sender, RoutedEventArgs e) =>
            NUDSelectedOrderProductPiece.Value = 0.25;
        private void YarımButton_Click(object sender, RoutedEventArgs e)=>
            NUDSelectedOrderProductPiece.Value = 0.5;
        private void DoubleButton_Click(object sender, RoutedEventArgs e) =>
            NUDSelectedOrderProductPiece.Value = 2;
        #endregion

        private void BillsButton_Click(object sender, RoutedEventArgs e)=>
            Nv.SetContent(Nv.Orders);
    }
}
