using System.Windows;
using System.Windows.Controls;

namespace RestoWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for BillsView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        private void DateButton_Click(object sender, RoutedEventArgs e)
        {
            DpDate.IsDropDownOpen = true;
        }
    }
}
