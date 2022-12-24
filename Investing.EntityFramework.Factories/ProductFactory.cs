using Investing.EntityFramework.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.EntityFramework.Factories
{
    public class ProductFactory : IEntityFrameworkFactory<Partner, Product>
    {
        public Product Create(Partner input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new Product
            {
                Issuer = input.Issuer,
                ClassCode = input.ClassCode,
                SecurCode = input.SecurCode,
                Asset = new Asset { Title = input.BaseAsset },
                Sector = new Entities.Sector { Title = input.Sector.Name },
                Logo = !string.IsNullOrEmpty(input.CompanyLogo) ? new ProductLogo { Value = input.CompanyLogo } : null,
                BondType = !string.IsNullOrEmpty(input.BondType) ? new BondType { Title = input.BondType } : null,
                Exchange = new Exchange { Title = input.Exchange },
                Portfolio = new Portfolio { Title = input.PortfolioName }
            };
        }
    }
}
