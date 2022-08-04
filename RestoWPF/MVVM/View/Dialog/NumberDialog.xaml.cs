using System;
using System.Windows;
using System.Windows.Controls;

namespace RestoWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for NumberDialog.xaml
    /// </summary>
    public partial class NumberDialog : UserControl
    {
        public decimal Piece { get; set; }
        public NumberDialog()
        {
            InitializeComponent();
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            txNumber.Text += ((Button)sender).Content;
            txNumber.Text = Convert.ToDecimal(txNumber.Text).ToString("0.##");
            Piece = Convert.ToDecimal(txNumber.Text);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txNumber.Text = "0";
            Piece = Convert.ToDecimal(txNumber.Text);
        }

    }
}
