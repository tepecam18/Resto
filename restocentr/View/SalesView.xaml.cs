using System.Windows;
using System.Windows.Controls;

namespace restocentr.View
{
    /// <summary>
    /// Interaction logic for SalesView.xaml
    /// </summary>
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();
        }

        private void BillsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TablesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CeyrekButton_Click(object sender, RoutedEventArgs e)
        {
            NUDSelectedOrderProductPiece.Value = 0.25;
        }

        private void YarımButton_Click(object sender, RoutedEventArgs e)
        {
            NUDSelectedOrderProductPiece.Value = 0.5;
        }

        private void DoubleButton_Click(object sender, RoutedEventArgs e)
        {
            NUDSelectedOrderProductPiece.Value = 2;
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
