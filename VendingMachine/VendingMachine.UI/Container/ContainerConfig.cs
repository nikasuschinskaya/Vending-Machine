using Autofac;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using VendingMachine.BLL.Managers;
using VendingMachine.DAL.DBContext;
using VendingMachine.DAL.Entities;
using VendingMachine.DAL.Repositories;
using VendingMachine.DAL.Repositories.Base;
using VendingMachine.UI.ViewModels;
using VendingMachine.UI.Views;

namespace VendingMachine.UI.Container
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var connectionString = ConfigurationManager.ConnectionStrings["sqlServerDB"].ConnectionString;

            builder.RegisterType<ApplicationDbContext>()
                            .WithParameter("options", new DbContextOptionsBuilder<ApplicationDbContext>()
                                            .UseSqlServer(connectionString)
                                            .Options)
                            .SingleInstance();

            builder.RegisterType<AdminRepository>().As<IRepository<AdminEntity>>();
            builder.RegisterType<CoinRepository>().As<IRepository<CoinEntity>>();
            builder.RegisterType<DrinkRepository>().As<IRepository<DrinkEntity>>();

            builder.RegisterType<DrinkManager>()
                       .WithParameter((pi, c) => pi.ParameterType == typeof(IRepository<DrinkEntity>),
                                       (pi, c) => c.Resolve<IRepository<DrinkEntity>>());

            builder.RegisterType<CoinManager>()
                       .WithParameter((pi, c) => pi.ParameterType == typeof(IRepository<CoinEntity>),
                                       (pi, c) => c.Resolve<IRepository<CoinEntity>>());

            builder.RegisterType<AutorizationManager>().AsSelf()
                        .WithParameter((pi, c) => pi.ParameterType == typeof(IRepository<AdminEntity>),
                                       (pi, c) => c.Resolve<IRepository<AdminEntity>>());

            builder.RegisterType<AdminManager>()
                       .WithParameter((pi, c) => pi.ParameterType == typeof(IRepository<DrinkEntity>),
                                      (pi, c) => c.Resolve<IRepository<DrinkEntity>>())
                       .WithParameter((pi, c) => pi.ParameterType == typeof(IRepository<CoinEntity>),
                                      (pi, c) => c.Resolve<IRepository<CoinEntity>>());


            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>()
                       .WithParameter((pi, c) => pi.ParameterType == typeof(CoinManager),
                                      (pi, c) => c.Resolve<CoinManager>())
                       .WithParameter((pi, c) => pi.ParameterType == typeof(DrinkManager),
                                                  (pi, c) => c.Resolve<DrinkManager>());

            builder.RegisterType<AutorizationWindow>().AsSelf();
            builder.RegisterType<AutorizationViewModel>()
                       .WithParameter((pi, c) => pi.ParameterType == typeof(AutorizationManager),
                                      (pi, c) => c.Resolve<AutorizationManager>());

            builder.RegisterType<AdminWindow>().AsSelf();
            builder.RegisterType<AdminViewModel>()
                       .WithParameter((pi, c) => pi.ParameterType == typeof(AdminManager),
                                      (pi, c) => c.Resolve<AdminManager>());

            return builder.Build();
        }
    }
}
