using StockData.Infrastructure.Entities;
using StockData.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace StockData.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company, Guid>, ICompanyRepository
    {
        public CompanyRepository(IStockDbContext context) : base((DbContext)context)
        {
            
        }
        public virtual Guid GetId(Company entity)
        {
            return entity.Id;
        }
    }
}
