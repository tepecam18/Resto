using RestoWPF.MVVM.ViewModel;
using RestoWPF.Static;
using System.Windows;
using System.Windows.Controls;

namespace RestoWPF.MVVM.View
{
    /// <summary>
    /// MainMenuView.xaml etkileşim mantığı
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
            this.DataContext = new MainMenuViewModel();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Nv.SetContent(Nv.Login);
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
    }
}
