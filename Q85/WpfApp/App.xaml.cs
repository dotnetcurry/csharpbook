using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string logPath = "errors.txt";

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception; // get exception
            // ...                          show the error to the user

            File.AppendAllText(logPath, exception.ToString());

            e.Handled = true;            // prevent the application from crashing
            Shutdown();                  // quit the application in a controlled way
        }
    }
}
