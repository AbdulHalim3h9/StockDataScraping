using StockData.Infrastructure.UnitOfWorks;
using CompanyBO = StockData.Infrastructure.BusinessObjects.Company;
using CompanyEO = StockData.Infrastructure.Entities.Company;
using StockPriceBO = StockData.Infrastructure.BusinessObjects.StockPrice;
using StockPriceEO = StockData.Infrastructure.Entities.StockPrice;

namespace StockData.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly ICompanyUnitOfWork _stockApplicationUnitOfWork;
        private readonly IStockPriceUnitOfWork _stockPriceUnitOfWork;
        private Guid _id = Guid.Empty;

        public StockService(ICompanyUnitOfWork companyApplicationUnitOfWork, IStockPriceUnitOfWork stockPriceUnitOfWork)
        {
            _stockApplicationUnitOfWork = companyApplicationUnitOfWork;
            _stockPriceUnitOfWork = stockPriceUnitOfWork;
        }

        public void CreateCompany(CompanyBO company)
        {
            CompanyEO companyEntity = new CompanyEO();
            companyEntity.TradeCode = company.TradeCode;
            var exists = _stockApplicationUnitOfWork.Companies.GetAll().Where(x => x.TradeCode == company.TradeCode).FirstOrDefault();
            if (exists == null) 
            {
                _stockApplicationUnitOfWork.Companies.Add(companyEntity);
                _stockApplicationUnitOfWork.Save();
            }
            _id = _stockApplicationUnitOfWork.Companies.GetAll().Where(x => x.TradeCode == company.TradeCode).FirstOrDefault().Id;
        }

            

        public void CreateStockPrice(StockPriceBO stockPrice)
        {

            StockPriceEO stockEntity = new StockPriceEO();
            stockEntity.Id = stockPrice.Id;
            stockEntity.LastTradingPrice = stockPrice.LastTradingPrice;
            stockEntity.High = stockPrice.High;
            stockEntity.Low = stockPrice.Low;
            stockEntity.ClosePrice = stockPrice.ClosePrice;
            stockEntity.YesterdayClosePrice = stockPrice.YesterdayClosePrice;
            stockEntity.Change = stockPrice.Change;
            stockEntity.Trade = stockPrice.Trade;
            stockEntity.Value = stockPrice.Value;
            stockEntity.Volume = stockPrice.Volume;
            stockEntity.CompanyId = _id;
            stockEntity.CreatedOn = DateTime.Now;

            _stockPriceUnitOfWork.StockPrices.Add(stockEntity);
            _stockPriceUnitOfWork.Save();
        }
    }
}
