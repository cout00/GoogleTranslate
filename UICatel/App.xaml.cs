using System;
using UICatel.Views;

namespace UICatel
{
    using System.Windows;

    using Catel.ApiCop;
    using Catel.ApiCop.Listeners;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.Reflection;
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App :Application
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.AddDebugListener();
            Log.Info("Starting application");
            Log.Info("Calling base.OnStartup");
#endif

            var directory = typeof(MainWindow).Assembly.GetDirectory();
            AppDomain.CurrentDomain.PreloadAssemblies(directory);


            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Get advisory report in console
            ApiCopManager.AddListener(new ConsoleApiCopListener());
            ApiCopManager.WriteResults();

            base.OnExit(e);
        }
    }
}