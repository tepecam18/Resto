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
    }
}
