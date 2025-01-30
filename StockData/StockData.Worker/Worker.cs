using Autofac;
using StockData.Infrastructure.Services;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IStockService _stockService;

        public Worker(ILogger<Worker> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Fetch fetch = new Fetch(_stockService);
                fetch.Get();
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}