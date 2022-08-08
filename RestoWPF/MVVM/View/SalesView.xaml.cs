﻿
/* Unmerged change from project 'RestoWPF (net6.0-windows)'
Before:
using System;
After:
using MahApps.Metro.Controls;
using RestoWPF.Static;
using System;
*/
using RestoWPF.Static;
using System.Windows;
using System.Windows.
/* Unmerged change from project 'RestoWPF (net6.0-windows)'
Before:
using System.Windows.Threading;
using MahApps.Metro.Controls;
using RestoWPF.Static;
After:
using System.Windows.Threading;
*/
Controls;

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
        private void YarımButton_Click(object sender, RoutedEventArgs e) =>
            NUDSelectedOrderProductPiece.Value = 0.5;
        private void DoubleButton_Click(object sender, RoutedEventArgs e) =>
            NUDSelectedOrderProductPiece.Value = 2;
        #endregion

        private void BillsButton_Click(object sender, RoutedEventArgs e) =>
            Nv.SetContent(Nv.Orders, false);
    }
}
