using Autofac;
using Autofac.Extensions.DependencyInjection;
using StockData.Worker;
using Serilog;
using Serilog.Events;
using System.Reflection;
using StockData.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StockData.Infrastructure.DbContexts;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var assemblyName = Assembly.GetExecutingAssembly().FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    Log.Information("Application Starting up");

    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .UseSerilog()
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            // builder.RegisterModule(new WorkerModule());
            builder.RegisterModule(new InfrastructureModule(connectionString,
            assemblyName));
            //builder.RegisterModule(new InfrastructureModule());
        })
        .ConfigureServices(services =>
        {
            services.AddHostedService<Worker>();
            services.AddDbContext<StockDbContext>(options =>
                options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
        })
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}











