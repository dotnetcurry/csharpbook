using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var timer = new DispatcherTimer();
            timer.IsEnabled = true;
            timer.Interval = new TimeSpan(50);
            timer.Tick += (source, eventArgs) =>
            {
                // code to execute
            };

        }
    }
}
