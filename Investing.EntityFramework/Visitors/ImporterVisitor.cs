using Investing.Core.Repository;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;

namespace Investing.EntityFramework.Visitors
{
    public class ImporterVisitor : IImporterVisitor
    {
        private readonly IRepository _repository;

        public ImporterVisitor(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Asset> Visit(Asset asset)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            asset.Id = (await _repository.TryImportAsync(asset)).Id;

            return asset;
        }

        public async Task<BondType> Visit(BondType bondType)
        {
            if (bondType == null) throw new ArgumentNullException(nameof(bondType));

            bondType.Id = (await _repository.TryImportAsync(bondType)).Id;

            return bondType;
        }

        public async Task<Currency> Visit(Currency currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            currency.Id = (await _repository.TryImportAsync(currency)).Id;

            return currency;
        }

        public async Task<Exchange> Visit(Exchange exchange)
        {
            if (exchange == null) throw new ArgumentNullException(nameof(exchange));

            exchange.Id = (await _repository.TryImportAsync(exchange)).Id;

            return exchange;
        }

        public async Task<Portfolio> Visit(Portfolio portfolio)
        {
            if (portfolio == null) throw new ArgumentNullException(nameof(portfolio));

            portfolio.Id = (await _repository.TryImportAsync(portfolio)).Id;

            return portfolio;
        }

        public async Task<Product> Visit(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (product.Asset != null)
            {
                product.AssetId = (await Visit(product.Asset)).Id;
            }

            if (product.Sector != null)
            {
                product.SectorId = (await Visit(product.Sector)).Id;
            }

            if (product.BondType != null)
            {
                product.BondTypeId = (await Visit(product.BondType)).Id;
            }

            if (product.Currency != null)
            {
                product.CurrencyId = (await Visit(product.Currency)).Id;
            }

            if (product.Exchange != null)
            {
                product.ExchangeId = (await Visit(product.Exchange)).Id;
            }

            if (product.Portfolio != null)
            {
                product.PortfolioId = (await Visit(product.Portfolio)).Id;
            }

            product.Id = (await _repository.TryImportAsync(product)).Id;

            if (product.Logo != null)
            {
                product.Logo.ProductId = product.Id;
                product.Logo.Id = (await Visit(product.Logo)).Id;
            }

            if (product.Prices != null)
            {
                foreach (var price in product.Prices)
                {
                    price.ProductId = product.Id;
                    price.Id = (await Visit(price)).Id;
                }
            }

            return product;
        }

        public async Task<ProductLogo> Visit(ProductLogo productLogo)
        {
            if (productLogo == null) throw new ArgumentNullException(nameof(productLogo));

            productLogo.Id = (await _repository.TryImportAsync(productLogo)).Id;

            return productLogo;
        }

        public async Task<ProductPrice> Visit(ProductPrice productPrice)
        {
            if (productPrice == null) throw new ArgumentNullException(nameof(productPrice));

            productPrice.Id = (await _repository.TryImportAsync(productPrice)).Id;

            return productPrice;
        }

        public async Task<Sector> Visit(Sector sector)
        {
            if (sector == null) throw new ArgumentNullException(nameof(sector));

            sector.Id = (await _repository.TryImportAsync(sector)).Id;

            return sector;
        }
    }
}
