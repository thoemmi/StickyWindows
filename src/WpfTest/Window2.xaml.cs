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

        public bool StickToScreen {
            get => _stickyWindow?.StickToScreen ?? true;
            set => _stickyWindow.StickToScreen = value;
        }

        public bool StickToOther {
            get => _stickyWindow?.StickToOther ?? true;
            set => _stickyWindow.StickToOther = value;
        }

        public bool StickOnResize {
            get => _stickyWindow?.StickOnResize ?? true;
            set => _stickyWindow.StickOnResize = value;
        }

        public bool StickOnMove {
            get => _stickyWindow?.StickOnMove ?? true;
            set => _stickyWindow.StickOnMove = value;
        }
    }
}