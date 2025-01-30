using Microsoft.EntityFrameworkCore;
using StockData.Infrastructure.DbContexts;
using StockData.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.UnitOfWorks
{
    public class StockPriceUnitOfWork : UnitOfWork, IStockPriceUnitOfWork
    {
        public IStockRepository StockPrices { get; private set; }
        public StockPriceUnitOfWork(IStockDbContext dbContext,
            IStockRepository stockRepository) : base((DbContext)dbContext)
        {
            StockPrices = stockRepository;
        }
    }
}
