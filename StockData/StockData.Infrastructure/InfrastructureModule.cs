using Autofac;
using StockData.Infrastructure.DbContexts;
using StockData.Infrastructure.Repositories;
using StockData.Infrastructure.Services;
using StockData.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StockDbContext>().As<IStockDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();
            builder.RegisterType<StockService>().As<IStockService>();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyUnitOfWork>().As<ICompanyUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StockPriceUnitOfWork>().As<IStockPriceUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StockRepository>().As<IStockRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
