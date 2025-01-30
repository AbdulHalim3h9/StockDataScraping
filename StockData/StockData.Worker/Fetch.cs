using Autofac;
using HtmlAgilityPack;
using StockData.Infrastructure.Services;

namespace StockData.Worker
{
    public class Fetch
    {
        private IStockService _stockService;
        public Fetch(IStockService stockService)
        {
            _stockService = stockService;
        }

        public void Get()
        {
            HtmlWeb web = new();
            HtmlDocument testDoc = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");
            HtmlNodeCollection nodes = testDoc.DocumentNode.SelectNodes("//div[contains(@class, 'table-responsive') and contains(@class, 'inner-scroll')]");
            HtmlNode MarketStatus = testDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'HeaderTop')]/span[3]/span");
            
            List<string> valueList = new List<string>();
            int count = 1;
            if (MarketStatus.InnerText == "Open")
            {
                foreach (HtmlNode hnode in nodes)
                {
                    var hn = hnode.SelectNodes("table//td");
                    foreach (var item in hn)
                    {
                        switch (count % 11)
                        {
                            case 2:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 3:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 4:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 5:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 6:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 7:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 8:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 9:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 10:
                                valueList.Add(item.InnerText.ToString().Trim());
                                break;
                            case 0:
                                valueList.Add(item.InnerText.ToString().Trim());
                                WriteData writeData = new(valueList,_stockService);
                                writeData.Write();
                                valueList.Clear();
                                break;
                        }
                        count++;

                    }
                }

            }

        }

    }
}
