using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Blue.Windows;
using StickyWindowLibrary;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private StickyWindow _stickyWindow;

        public Window1()
        {
            InitializeComponent();
            this.Loaded += window1Loaded;
        }

        void window1Loaded(object sender, RoutedEventArgs e)
        {
           
            StickyWindow.RegisterExternalReferenceForm(this);
        }


        private void newWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
        }
    }
}