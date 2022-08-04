using RestoWPF.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace RestoWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for TablesView.xaml
    /// </summary>
    public partial class TablesView : UserControl
    {
        double left, top;
        FrameworkElement? root;

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
            if (left < 0)
            {
                Canvas.SetLeft(root, 0);
            }
            if (top < 0)
            {
                Canvas.SetTop(root, 0);
            }
        }
    }
}
