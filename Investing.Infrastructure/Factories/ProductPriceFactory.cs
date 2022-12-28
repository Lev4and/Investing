using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.Infrastructure.Factories
{
    public class ProductPriceFactory : IEntityFrameworkFactory<Quotation, ProductPrice>
    {
        private readonly Guid _productId;

        public ProductPriceFactory(Guid productId) 
        {
            if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));

            _productId = productId;
        }

        public ProductPrice Create(Quotation input)
        {
            return new ProductPrice
            {
                ProductId = _productId,
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
