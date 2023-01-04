using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.Infrastructure.Factories
{
    public class ProductBaseFactory : IEntityFrameworkFactory<PartnerBase, Product>
    {
        public Product Create(PartnerBase input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new Product
            {
                Issuer = input.Issuer,
                ClassCode = input.ClassCode,
                SecurCode = input.SecurCode,
                Capitalization = (decimal?)input.Capitalization,
                Asset = !string.IsNullOrEmpty(input.BaseAsset) ? new Asset { Title = input.BaseAsset } : null,
                Currency = new Currency { Title = input.Currency },
                Sector = new EntityFramework.Entities.Sector { Title = input.Sector.Name },
                Logo = !string.IsNullOrEmpty(input.CompanyLogo) ? new ProductLogo { Value = input.CompanyLogo } : null,
                BondType = !string.IsNullOrEmpty(input.BondType) ? new BondType { Title = input.BondType } : null,
                Exchange = new Exchange { Title = input.Exchange },
                Portfolio = new Portfolio { Title = input.PortfolioName }
            };
        }
    }
}
