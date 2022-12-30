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

            asset = await _repository.TryImportAsync(asset);

            return asset;
        }

        public async Task<BondType> Visit(BondType bondType)
        {
            if (bondType == null) throw new ArgumentNullException(nameof(bondType));

            bondType = await _repository.TryImportAsync(bondType);

            return bondType;
        }

        public async Task<Currency> Visit(Currency currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            currency = await _repository.TryImportAsync(currency);

            return currency;
        }

        public async Task<Exchange> Visit(Exchange exchange)
        {
            if (exchange == null) throw new ArgumentNullException(nameof(exchange));

            exchange = await _repository.TryImportAsync(exchange);

            return exchange;
        }

        public async Task<Portfolio> Visit(Portfolio portfolio)
        {
            if (portfolio == null) throw new ArgumentNullException(nameof(portfolio));

            portfolio = await _repository.TryImportAsync(portfolio);

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

            await _repository.TryImportAsync(product);

            if (product.Logo != null)
            {
                product.Logo.ProductId = product.Id;

                await Visit(product.Logo);
            }

            return product;
        }

        public async Task<ProductLogo> Visit(ProductLogo productLogo)
        {
            if (productLogo == null) throw new ArgumentNullException(nameof(productLogo));

            productLogo = await _repository.TryImportAsync(productLogo);

            return productLogo;
        }

        public async Task<ProductPrice> Visit(ProductPrice productPrice)
        {
            if (productPrice == null) throw new ArgumentNullException(nameof(productPrice));

            productPrice = await _repository.TryImportAsync(productPrice);

            return productPrice;
        }

        public async Task<Sector> Visit(Sector sector)
        {
            if (sector == null) throw new ArgumentNullException(nameof(sector));

            sector = await _repository.TryImportAsync(sector);

            return sector;
        }
    }
}
