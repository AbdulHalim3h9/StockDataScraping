using StockData.Infrastructure.DbContexts;
using StockData.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace StockData.Infrastructure.UnitOfWorks
{
    public class CompanyUnitOfWork : UnitOfWork, ICompanyUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }

        public CompanyUnitOfWork(IStockDbContext dbContext,
            ICompanyRepository companyRepository) : base((DbContext)dbContext)
        {
            Companies = companyRepository;
        }
    }
}
