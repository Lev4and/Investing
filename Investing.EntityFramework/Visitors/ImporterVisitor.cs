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

        public async Task<Asset> ImportAsync(Asset asset)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            return await _repository.TryImportAsync(asset);
        }

        public async Task<BondType> ImportAsync(BondType bondType)
        {
            if (bondType == null) throw new ArgumentNullException(nameof(bondType));

            return await _repository.TryImportAsync(bondType);
        }

        public async Task<Currency> ImportAsync(Currency currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            return await _repository.TryImportAsync(currency);
        }

        public async Task<Exchange> ImportAsync(Exchange exchange)
        {
            if (exchange == null) throw new ArgumentNullException(nameof(exchange));

            return await _repository.TryImportAsync(exchange);
        }

        public async Task<Portfolio> ImportAsync(Portfolio portfolio)
        {
            if (portfolio == null) throw new ArgumentNullException(nameof(portfolio));

            return await _repository.TryImportAsync(portfolio);
        }

        public async Task<Product> ImportAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (product.Asset != null)
            {
                product.AssetId = (await ImportAsync(product.Asset)).Id;
            }

            if (product.Sector != null)
            {
                product.SectorId = (await ImportAsync(product.Sector)).Id;
            }

            if (product.BondType != null)
            {
                product.BondTypeId = (await ImportAsync(product.BondType)).Id;
            }

            if (product.Currency != null)
            {
                product.CurrencyId = (await ImportAsync(product.Currency)).Id;
            }

            if (product.Exchange != null)
            {
                product.ExchangeId = (await ImportAsync(product.Exchange)).Id;
            }

            if (product.Portfolio != null)
            {
                product.PortfolioId = (await ImportAsync(product)).Id;
            }

            var result = await _repository.TryImportAsync(product);

            if (product.Logo != null)
            {
                product.Logo.ProductId = product.Id;

                await ImportAsync(product.Logo);
            }

            return result;
        }

        public async Task<ProductLogo> ImportAsync(ProductLogo productLogo)
        {
            if (productLogo == null) throw new ArgumentNullException(nameof(productLogo));

            return await _repository.TryImportAsync(productLogo);
        }

        public async Task<ProductPrice> ImportAsync(ProductPrice productPrice)
        {
            if (productPrice == null) throw new ArgumentNullException(nameof(productPrice));

            return await _repository.TryImportAsync(productPrice);
        }

        public async Task<Sector> ImportAsync(Sector sector)
        {
            if (sector == null) throw new ArgumentNullException(nameof(sector));

            return await _repository.TryImportAsync(sector);
        }
    }
}
