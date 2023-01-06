using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.Infrastructure.Factories
{
    public class ProductDividendFactory : IEntityFrameworkFactory<Dividend, ProductDividend>
    {
        public ProductDividend Create(Dividend input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new ProductDividend
            {
                Title = input.CompanyName,
                Yield = input.Yield,
                ClosePrice = input.ClosePrice,
                DividendValue = input.DividendValue,
                LastBuyDay = input.LastBuyDay.ToUniversalTime(),
                ClosingDate = input.ClosingDate.ToUniversalTime(),
            };
        }
    }
}
