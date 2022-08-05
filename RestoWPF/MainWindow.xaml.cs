﻿using MahApps.Metro.Controls;
using RestoWPF.MVVM.ViewModel;
using RestoWPF.Static;
using System.Windows;
using System.Windows.Input;

namespace RestoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow 
    {
        internal static MainViewModel viewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
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

        private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
            => MainScrollViewer.ScrollToHome();


        private void BackNavButton_Click(object sender, RoutedEventArgs e)
        {
            Nv.GetBack();
        }
    }
}
