using Realms;
using RestoWPF.Core;
using RestoWPF.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for TablesView.xaml
    /// </summary>
    public partial class TablesView : UserControl
    {
        double left, top;
        FrameworkElement? root;

        Realm realm = Realm.GetInstance(new ConstantRealmConfig());
        TablesViewModel ViewModel = new TablesViewModel();

        public TablesView()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Thumb? thumb = sender as Thumb;
            root = VisualTreeHelper.GetParent(thumb) as FrameworkElement;
            root = VisualTreeHelper.GetParent(root) as FrameworkElement;
            left = Canvas.GetLeft(root);
            top = Canvas.GetTop(root);

            left += e.HorizontalChange;
            top += e.VerticalChange;

            Canvas.SetLeft(root, left);
            Canvas.SetTop(root, top);

        }

        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            realm.Write(() =>
            {
                if (left < 0)
                {
                    Canvas.SetLeft(root, 0);
                }
                if (top < 0)
                {
                    Canvas.SetTop(root, 0);
                }
            });
        }
    }
}
