using Autofac;
using System.Windows;
using VendingMachine.UI.Container;

namespace VendingMachine.UI
{
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Container = ContainerConfig.Configure();
        }
    }
}
