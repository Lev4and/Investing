using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.Infrastructure.Factories
{
    public class ProductPriceFactory : IEntityFrameworkFactory<Quotation, ProductPrice>
    {
        public ProductPrice Create(Quotation input)
        {
            return new ProductPrice
            {
                Open = input.Open,
                High = input.High,
                Low = input.Low,
                Close = input.Close,
                Volume = input.Volume,
                ClosedAt = input.Time
            };
        }
    }
}
