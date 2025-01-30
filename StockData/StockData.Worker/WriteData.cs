using Autofac;
using StockData.Infrastructure.BusinessObjects;
using StockData.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class WriteData
    {
        private IStockService _stockService;
        private List<string> _values;
        public WriteData(List<string> val, IStockService stockService)
        {
            _values = val;
            _stockService = stockService;
        }
        public void Write()
        {
            
            string TradeCode = _values.FirstOrDefault();
            _values.Remove(TradeCode);

            Company company = new Company();
            StockPrice stockPrice = new StockPrice();
            company.Id = Guid.NewGuid();
            company.TradeCode = TradeCode;
            _stockService.CreateCompany(company);

            string[] valueDoubles = _values.ToArray();
            _values.Clear();
            //stockPrice.Id = Guid.NewGuid();

            stockPrice.LastTradingPrice = (valueDoubles[0] == "--") ? null : Convert.ToDouble(valueDoubles[0]);
            stockPrice.High = (valueDoubles[1] == "--") ? null : Convert.ToDouble(valueDoubles[1]);
            stockPrice.Low = (valueDoubles[2] == "--") ? null : Convert.ToDouble(valueDoubles[2]);
            stockPrice.ClosePrice = (valueDoubles[3] == "--") ? null : Convert.ToDouble(valueDoubles[3]);
            stockPrice.YesterdayClosePrice = (valueDoubles[4] == "--") ? null : Convert.ToDouble(valueDoubles[4]);
            stockPrice.Change = (valueDoubles[5] == "--") ? null : Convert.ToDouble(valueDoubles[5]);
            stockPrice.Trade = (valueDoubles[6] == "--") ? null : Convert.ToDouble(valueDoubles[6]);
            stockPrice.Value = (valueDoubles[7] == "--") ? null : Convert.ToDouble(valueDoubles[7]);
            stockPrice.Volume = (valueDoubles[8] == "--") ? null : Convert.ToDouble(valueDoubles[8]);
            stockPrice.CompanyId = company.Id;

            _stockService.CreateStockPrice(stockPrice);
        }
    }
}
