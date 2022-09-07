using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace restocentr.Component.Template
{
    /// <summary>
    /// Interaction logic for PanningTemplate.xaml
    /// </summary>
    public partial class PanningTemplate : UserControl
    {
        #region Data
        private Point scrollTarget;
        private Point scrollStartPoint;
        private Point scrollStartOffset;
        private static int PixelsToMoveToBeConsideredScroll = 5;
        private static int PixelsToMoveToBeConsideredClick = 40;
        private bool IsMouseClick = false;
        private ListBoxItem _listBoxItem = new ListBoxItem();
        #endregion

        #region Ctor
        public PanningTemplate()
        {
            InitializeComponent();
        }
        #endregion

        #region param
        public object AdditionalContent
        {
            get { return (object)GetValue(AdditionalContentProperty); }
            set { SetValue(AdditionalContentProperty, value); }
        }
        public static readonly DependencyProperty AdditionalContentProperty =
            DependencyProperty.Register("AdditionalContent", typeof(object), typeof(PanningTemplate),
              new PropertyMetadata(null));

        public ScrollBarVisibility IsVertical { get; set; }
        public static readonly DependencyProperty IsVerticalProperty =
            DependencyProperty.Register("IsVertical", typeof(ScrollBarVisibility), typeof(PanningTemplate),
              new PropertyMetadata(null));

        public ScrollBarVisibility IsHorizontal { get; set; }
        public static readonly DependencyProperty IsHorizontalProperty =
            DependencyProperty.Register("IsHorizontal", typeof(ScrollBarVisibility), typeof(PanningTemplate),
              new PropertyMetadata(null));
        #endregion

        #region Pan
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            scrollStartPoint = e.GetPosition(this);
            scrollStartOffset.X = sv.HorizontalOffset;
            scrollStartOffset.Y = sv.VerticalOffset;

            listBoxItem = TreeHelper.TryFindFromPoint<ListBoxItem>(this, scrollStartPoint);
            if (listBoxItem != null)
            {
                listBoxItem.IsSelected = false;
                listBoxItem.IsEnabled = false;
            }

            IsMouseClick = true;
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseClick)
            {
                Point currentPoint = e.GetPosition(this);

                // Determine the new amount to scroll.
                Point delta = new Point(scrollStartPoint.X - currentPoint.X, scrollStartPoint.Y - currentPoint.Y);

                if (Math.Abs(delta.X) < PixelsToMoveToBeConsideredScroll &&
                    Math.Abs(delta.Y) < PixelsToMoveToBeConsideredScroll)
                    return;

                // JH Start - Update the cursor to scrolling if it's moved and release the pressed state
                this.Cursor = (sv.ExtentWidth > sv.ViewportWidth) || (sv.ExtentHeight > sv.ViewportHeight) ? Cursors.ScrollAll : Cursors.Arrow;
                // JH End - Update the cursor to scrolling if it's moved and release the pressed state


                scrollTarget.X = scrollStartOffset.X + delta.X;
                // JH Start - Don't want vertical scrolling
                scrollTarget.Y = scrollStartOffset.Y + delta.Y;
                // JH End - Don't want vertical scrolling

                // Scroll to the new position.
                sv.ScrollToHorizontalOffset(scrollTarget.X);
                // JH Start - Don't want vertical scrolling
                sv.ScrollToVerticalOffset(scrollTarget.Y);
                // JH End - Don't want vertical scrolling
            }
        }

        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseClick = false;

            Point currentPoint = e.GetPosition(this);

            // Determine the new amount to scroll.
            Point delta = new Point(scrollStartPoint.X - currentPoint.X, scrollStartPoint.Y - currentPoint.Y);
            if (listBoxItem != null)
            {
                listBoxItem.IsEnabled = true;

                if (Math.Abs(delta.X) < PixelsToMoveToBeConsideredClick &&
                    Math.Abs(delta.Y) < PixelsToMoveToBeConsideredClick)
                {
                    var x = TreeHelper.TryFindFromPoint<ListBoxItem>(this, scrollStartPoint);

                    if (x != null)
                    {
                        x.IsSelected = true;
                    }

                }
            }
        }
        #endregion

        #region Method
        private ListBoxItem listBoxItem
        {
            get
            {
                return _listBoxItem;
            }
            set
            {
                //listBoxItem First Selected Is Enabled true
                _listBoxItem.IsEnabled = true;
                if (value != null)
                {
                    _listBoxItem = value;
                }
            }
        }
        #endregion
    }
}
