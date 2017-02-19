using System.Windows;
using System.Windows.Interactivity;

namespace StickyWindows.WPF {
    public class StickyWindowBehavior : Behavior<Window> {
        private StickyWindow _stickyWindow;

        protected override void OnAttached() {
            _stickyWindow?.ReleaseHandle();

            base.OnAttached();

            if (AssociatedObject.IsLoaded) {
                _stickyWindow = AssociatedObject.CreateStickyWindow();
            } else {
                AssociatedObject.Loaded += OnLoaded;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs args) {
            AssociatedObject.Loaded -= OnLoaded;
            _stickyWindow = AssociatedObject.CreateStickyWindow();
        }

        protected override void OnDetaching() {
            AssociatedObject.Loaded -= OnLoaded;
            base.OnDetaching();
            _stickyWindow?.ReleaseHandle();
        }
    }
}