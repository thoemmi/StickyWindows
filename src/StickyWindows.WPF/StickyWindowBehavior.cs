using System.Windows;
using System.Windows.Interactivity;

namespace StickyWindows.WPF {
    public class StickyWindowBehavior : Behavior<Window> {
        private static readonly DependencyProperty StickyWindowProperty = DependencyProperty.Register(
            "StickyWindow", typeof(StickyWindow), typeof(StickyWindowBehavior), new PropertyMetadata(default(StickyWindow)));

        public static readonly DependencyProperty StickToScreenProperty = DependencyProperty.Register(
            "StickToScreen", typeof(bool), typeof(StickyWindowBehavior), new PropertyMetadata(true, OnStickToScreenChanged));

        public static readonly DependencyProperty StickToOtherProperty = DependencyProperty.Register(
            "StickToOther", typeof(bool), typeof(StickyWindowBehavior), new PropertyMetadata(true, OnStickToOtherChanged));

        public static readonly DependencyProperty StickOnResizeProperty = DependencyProperty.Register(
            "StickOnResize", typeof(bool), typeof(StickyWindowBehavior), new PropertyMetadata(true, OnStickOnResizeChanged));

        public static readonly DependencyProperty StickOnMoveProperty = DependencyProperty.Register(
            "StickOnMove", typeof(bool), typeof(StickyWindowBehavior), new PropertyMetadata(true, OnStickOnMoveChanged));

        private StickyWindow StickyWindow {
            get { return (StickyWindow)GetValue(StickyWindowProperty); }
            set { SetValue(StickyWindowProperty, value); }
        }

        public bool StickToScreen {
            get { return (bool)GetValue(StickToScreenProperty); }
            set { SetValue(StickToScreenProperty, value); }
        }

        public bool StickToOther {
            get { return (bool)GetValue(StickToOtherProperty); }
            set { SetValue(StickToOtherProperty, value); }
        }

        public bool StickOnResize {
            get { return (bool)GetValue(StickOnResizeProperty); }
            set { SetValue(StickOnResizeProperty, value); }
        }

        public bool StickOnMove {
            get { return (bool)GetValue(StickOnMoveProperty); }
            set { SetValue(StickOnMoveProperty, value); }
        }

        private static void OnStickToScreenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var stickyWindow = (StickyWindow)d.GetValue(StickyWindowProperty);
            if (stickyWindow != null) {
                stickyWindow.StickToScreen = (bool)e.NewValue;
            }
        }

        private static void OnStickToOtherChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var stickyWindow = (StickyWindow)d.GetValue(StickyWindowProperty);
            if (stickyWindow != null) {
                stickyWindow.StickToOther = (bool)e.NewValue;
            }
        }

        private static void OnStickOnResizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var stickyWindow = (StickyWindow)d.GetValue(StickyWindowProperty);
            if (stickyWindow != null) {
                stickyWindow.StickOnResize = (bool)e.NewValue;
            }
        }

        private static void OnStickOnMoveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var stickyWindow = (StickyWindow)d.GetValue(StickyWindowProperty);
            if (stickyWindow != null) {
                stickyWindow.StickOnMove = (bool)e.NewValue;
            }
        }

        protected override void OnAttached() {
            StickyWindow?.ReleaseHandle();

            base.OnAttached();

            if (AssociatedObject.IsLoaded) {
                CreateStickyWindow();
            } else {
                AssociatedObject.Loaded += OnLoaded;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs args) {
            AssociatedObject.Loaded -= OnLoaded;
            CreateStickyWindow();
        }

        private void CreateStickyWindow() {
            var stickyWindow = AssociatedObject.CreateStickyWindow();
            stickyWindow.StickToScreen = StickToScreen;
            stickyWindow.StickToOther = StickToOther;
            stickyWindow.StickOnResize = StickOnResize;
            stickyWindow.StickOnMove = StickOnMove;
            StickyWindow = stickyWindow;
        }

        protected override void OnDetaching() {
            AssociatedObject.Loaded -= OnLoaded;
            base.OnDetaching();
            StickyWindow?.ReleaseHandle();
            StickyWindow = null;
        }
    }
}