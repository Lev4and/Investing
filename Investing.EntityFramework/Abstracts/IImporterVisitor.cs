using Investing.Core.Abstracts;
using Investing.EntityFramework.Entities;

namespace Investing.EntityFramework.Abstracts
{
    public interface IImporterVisitor
    {
        Task<Asset> Visit(Asset asset);

        Task<BondType> Visit(BondType bondType);

        Task<Currency> Visit(Currency currency);

        Task<Exchange> Visit(Exchange exchange);

        Task<Portfolio> Visit(Portfolio portfolio);

        Task<Product> Visit(Product product);

        Task<ProductDividend> Visit(ProductDividend dividend);

        Task<ProductLogo> Visit(ProductLogo productLogo);

        Task<ProductPrice> Visit(ProductPrice productPrice);

        Task<Sector> Visit(Sector sector);
    }
}
