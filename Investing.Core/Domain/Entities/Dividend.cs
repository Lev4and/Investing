namespace Investing.Core.Domain.Entities
{
    public class Dividend
    {
        public decimal? Yield { get; }

        public decimal ClosePrice { get; }

        public decimal DividendValue { get; }

        public string CompanyName { get; }

        public DateTime LastBuyDay { get; }

        public DateTime ClosingDate { get; }

        public Dividend(decimal? yield, decimal closePrice, decimal dividendValue, string companyName, 
            DateTime lastBuyDay, DateTime closingDate)
        {
            Yield = yield;
            ClosePrice = closePrice;
            DividendValue = dividendValue;
            CompanyName = companyName;
            LastBuyDay = lastBuyDay;
            ClosingDate = closingDate;
        }
    }
}
