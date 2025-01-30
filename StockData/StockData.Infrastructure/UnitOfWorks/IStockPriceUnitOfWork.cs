using StockData.Infrastructure.Repositories;

namespace StockData.Infrastructure.UnitOfWorks
{
    public interface IStockPriceUnitOfWork
    {
        IStockRepository StockPrices { get; }

        void Save();
    }
}