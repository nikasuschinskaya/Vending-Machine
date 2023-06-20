using Autofac;
using System.Windows;
using VendingMachine.UI.Container;
using VendingMachine.UI.Views;

namespace VendingMachine.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Container = ContainerConfig.Configure();

            //var mainWindow = Container.Resolve<MainWindow>();
            //mainWindow.Show();
        }
    }
}
