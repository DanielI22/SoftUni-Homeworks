using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization > 10000 && this.MoneyToInvest>= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest-=stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock currentStock = Portfolio.FirstOrDefault(c => c.CompanyName == companyName);
            if(currentStock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < currentStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(currentStock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(c => c.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if(Portfolio.Count == 0)
            {
                return null;
            }

            decimal maxCap = Portfolio.Max(cap => cap.MarketCapitalization);
            return Portfolio.FirstOrDefault(c => c.MarketCapitalization == maxCap);
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
