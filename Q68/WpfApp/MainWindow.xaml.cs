using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void OnEventRaised(object sender, EventArgs e)
        {
            // ...
        }

        private void MyEventHandler(object sender, RoutedEventArgs e)
        {
            var instance = new InnocentLookingClass();
            // further code
        }

        private void MyEventHandlerFixed(object sender, RoutedEventArgs e)
        {
            var instance = new InnocentLookingClass(false);
            // further code
        }
    }
}
