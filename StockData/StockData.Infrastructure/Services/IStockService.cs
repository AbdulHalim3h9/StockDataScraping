
using StockData.Infrastructure.BusinessObjects;

namespace StockData.Infrastructure.Services
{
    public interface IStockService
    {
        void CreateCompany(Company company);
        void CreateStockPrice(StockPrice price);
    }
}