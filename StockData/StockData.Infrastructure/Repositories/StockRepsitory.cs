using Microsoft.EntityFrameworkCore;
using StockData.Infrastructure.DbContexts;
using StockData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories
{
    public class StockRepository : Repository<StockPrice, Guid>, IStockRepository
    {
        public StockRepository(IStockDbContext context) : base((DbContext)context)
        {
        }
    }
}
