using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using restocentr.Static;
using restocentr.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace restocentr.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        internal static MainWindowViewModel viewModel = new MainWindowViewModel();
        public static Snackbar snackbar;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            snackbar = RootSnackbar;
        }

        #region windows border

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SimpleButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void WindowStateSimpleButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void CloseSimpleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #endregion

        private void BackNavButton_Click(object sender, RoutedEventArgs e)
        {
            Nv.GetBack();
        }
    }
}
