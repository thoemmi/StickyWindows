using System.Windows;
using Blue.Windows;

namespace WpfTest {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            Loaded += window1Loaded;
        }

        private void window1Loaded(object sender, RoutedEventArgs e) {
            StickyWindow.RegisterExternalReferenceForm(this);
        }


        private void newWindowButton_Click(object sender, RoutedEventArgs e) {
            var win2 = new Window2();
            win2.Show();
        }
    }
}