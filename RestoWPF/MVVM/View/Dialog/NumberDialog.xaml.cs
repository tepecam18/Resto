
using RestoWPF.Core;
using RestoWPF.MVVM.Model;
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
