using StockData.Infrastructure.Entities;
using StockData.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories
{
    public interface ICompanyRepository : IRepository<Company, Guid>
    {
        Guid GetId(Company entity);
    }
}
