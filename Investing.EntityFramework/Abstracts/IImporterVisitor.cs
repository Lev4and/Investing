using Investing.EntityFramework.Entities;

namespace Investing.EntityFramework.Abstracts
{
    public interface IImporterVisitor
    {
        Task<Asset> ImportAsync(Asset asset);

        Task<BondType> ImportAsync(BondType bondType);

        Task<Currency> ImportAsync(Currency currency);

        Task<Exchange> ImportAsync(Exchange exchange);

        Task<Portfolio> ImportAsync(Portfolio portfolio);

        Task<Product> ImportAsync(Product product);

        Task<ProductLogo> ImportAsync(ProductLogo productLogo);

        Task<ProductPrice> ImportAsync(ProductPrice productPrice);

        Task<Sector> ImportAsync(Sector sector);
    }
}
