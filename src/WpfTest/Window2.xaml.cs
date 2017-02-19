using System.Windows;
using StickyWindows;
using StickyWindows.WPF;

namespace WpfTest {
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window {
        private StickyWindow _stickyWindow;

        public Window2() {
            InitializeComponent();
            Loaded += window1Loaded;
        }

        private void window1Loaded(object sender, RoutedEventArgs e) {
            _stickyWindow = this.CreateStickyWindow();
            _stickyWindow.StickToScreen = true;
            _stickyWindow.StickToOther = true;
            _stickyWindow.StickOnResize = true;
            _stickyWindow.StickOnMove = true;
        }
    }
}