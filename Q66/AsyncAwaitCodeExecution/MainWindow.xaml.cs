using System.Net;
using System.Windows;

namespace AsyncAwaitCodeExecution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string requestedUri = "http://www.google.com";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickSync(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Downloading...";

            var request = WebRequest.Create(requestedUri);
            using (WebResponse response = request.GetResponse())
            {
                StatusText.Text = string.Empty;

                // process the response
            }
        }

        private async void OnClickAsync(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Downloading...";

            var request = WebRequest.Create(requestedUri);
            using (WebResponse response = await request.GetResponseAsync())
            {
                StatusText.Text = string.Empty;

                // process the response
            }
        }
    }
}
