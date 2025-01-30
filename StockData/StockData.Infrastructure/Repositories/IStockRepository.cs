﻿using StockData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories
{
    public interface IStockRepository : IRepository<StockPrice, Guid>
    {
    }
}
