using StockData.Infrastructure.Repositories;
using StockData.Infrastructure.UnitOfWorks;

namespace StockData.Infrastructure.UnitOfWorks
{
    public interface ICompanyUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Companies { get; }
    }
}