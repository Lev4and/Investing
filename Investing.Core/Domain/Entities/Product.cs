namespace Investing.Core.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Issuer { get; }

        public string ClassCode { get; }

        public string SecurCode { get; }

        public decimal? Capitalization { get; }

        public Asset? Asset { get; }

        public Sector Sector { get; }

        public Currency Currency { get; }

        public Exchange Exchange { get; }

        public ProductLogo? Logo { get; }

        public BondType? BondType { get; }

        public Portfolio Portfolio { get; }

        public ProductPrices Prices { get; }

        public ProductDividends Dividends { get; }

        public Product(Guid id, string issuer, string classCode, string securCode, decimal? capitalization, Asset? asset, 
            Sector sector, Currency currency, Exchange exchange, ProductLogo? logo, BondType? bondType, 
            Portfolio portfolio, ProductPrices prices, ProductDividends dividends) 
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrEmpty(issuer)) throw new ArgumentNullException(nameof(issuer));
            if (string.IsNullOrEmpty(classCode)) throw new ArgumentNullException(nameof(classCode));
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));
            if (sector == null) throw new ArgumentNullException(nameof(sector));
            if (currency == null) throw new ArgumentNullException(nameof(currency));
            if (exchange == null) throw new ArgumentNullException(nameof(exchange));
            if (portfolio == null) throw new ArgumentNullException(nameof(portfolio));
            if (prices == null) throw new ArgumentNullException(nameof(prices));
            if (dividends == null) throw new ArgumentNullException(nameof(dividends));

            Id = id;
            Issuer = issuer;
            ClassCode = classCode;
            SecurCode = securCode;
            Capitalization = capitalization;
            Asset = asset;
            Sector = sector;
            Currency = currency;
            Exchange = exchange;
            Logo = logo;
            BondType = bondType;
            Portfolio = portfolio;
            Prices = prices;
            Dividends = dividends;
        }
    }
}
