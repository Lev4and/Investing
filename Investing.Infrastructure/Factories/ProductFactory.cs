using Investing.Core.Abstracts;
using DomainEntities = Investing.Core.Domain.Entities;
using EntityFrameworkEntities = Investing.EntityFramework.Entities;

namespace Investing.Infrastructure.Factories
{
    public class ProductFactory : IFactory<EntityFrameworkEntities.Product, DomainEntities.Product>
    {
        public DomainEntities.Product Create(EntityFrameworkEntities.Product input)
        {
            var asset = input.Asset != null 
                ? new DomainEntities.Asset(input.Asset.Id, input.Asset.Title) 
                : null;

            var sector = new DomainEntities.Sector(input.Sector.Id, input.Sector.Title);
            var currency = new DomainEntities.Currency(input.Currency.Id, input.Currency.Title);
            var exchange = new DomainEntities.Exchange(input.Exchange.Id, input.Exchange.Title);

            var logo = input.Logo != null 
                ? new DomainEntities.ProductLogo(input.Logo.Value) 
                : null;

            var bondType = input.BondType != null 
                ? new DomainEntities.BondType(input.BondType.Id, input.BondType.Title) 
                : null;

            var portfolio = new DomainEntities.Portfolio(input.Portfolio.Id, input.Portfolio.Title);

            var prices = input.Prices != null
                ? new DomainEntities.ProductPrice(input.Prices.Select(price => new DomainEntities.Ohlc(price.Low,
                    price.Open, price.High, price.Close, price.Volume, price.ClosedAt)))
                : new DomainEntities.ProductPrice(new List<DomainEntities.Ohlc>());

            return new DomainEntities.Product(input.Id, input.Issuer, input.ClassCode, input.SecurCode,
                input.Capitalization, asset, sector, currency, exchange, logo, bondType, portfolio, prices);
        }
    }
}
