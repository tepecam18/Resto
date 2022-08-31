using restocentr.Static;
using System.Windows;
using System.Windows.Controls;

namespace restocentr.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Log.Show("sane");
        }

        private void Satis_Button_Click(object sender, RoutedEventArgs e)
        {
            Nv.SetContent(Nv.Sales);
        }

        private void Ayarlar_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Raporlar_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Nv.SetContent(Nv.Login);
        }
    }
}
