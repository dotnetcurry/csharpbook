using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncFileOperations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource = null;
        private readonly string path = "TextFile1.txt";
        private readonly int bufferSize = 4096;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private string ReadAllText(string filepath)
        {
            var buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();

            using (var stream = new FileStream(filepath, FileMode.Open))
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stringBuilder.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                }
                return stringBuilder.ToString();
            }
        }

        private async Task<string> ReadAllTextAsync(string filepath)
        {
            var buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();

            using (var stream = new FileStream(filepath, FileMode.Open))
            {
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    stringBuilder.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                }
                return stringBuilder.ToString();
            }
        }

        private async Task<string> ReadAllTextAsync(string filepath, CancellationToken cancellationToken)
        {
            var buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();

            using (var stream = new FileStream(filepath, FileMode.Open))
            {
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                {
                    stringBuilder.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                }
                return stringBuilder.ToString();
            }
        }

        private async Task<string> ReadAllTextAsync(string filepath, IProgress<int> progress, CancellationToken cancellationToken)
        {
            var fileInfo = new FileInfo(filepath);
            var fileSize = (int)fileInfo.Length;
            var buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();

            using (var stream = new FileStream(filepath, FileMode.Open))
            {
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                {
                    stringBuilder.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                    progress.Report(stringBuilder.Length * 100 / fileSize);
                }
                return stringBuilder.ToString();
            }
        }


        private void OnSynchronous(object sender, RoutedEventArgs e)
        {
            var text = ReadAllText(path);
        }


        private async void OnAsynchronous(object sender, RoutedEventArgs e)
        {
            var text = await ReadAllTextAsync(path);
        }


        private async void OnWithCancellation(object sender, RoutedEventArgs e)
        {
            try
            {
                using (cancellationTokenSource = new CancellationTokenSource())
                {
                    var text = await ReadAllTextAsync(path, cancellationTokenSource.Token);
                }

                cancellationTokenSource = null;
            }
            catch (OperationCanceledException)
            { }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private async void OnWithProgress(object sender, RoutedEventArgs e)
        {
            using (cancellationTokenSource = new CancellationTokenSource())
            {
                try
                {
                    var progress = new Progress<int>(percent => ProgressBar.Value = percent);
                    var text = await ReadAllTextAsync(path, progress, cancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                { }
            }

            cancellationTokenSource = null;
        }
    }
}
