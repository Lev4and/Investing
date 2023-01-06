namespace Investing.Core.Domain.Entities
{
    public class ProductPrices : LinkedList<Ohlc>
    {
        public ProductPrices(IEnumerable<Ohlc> prices) : base(prices.OrderBy(price => price.ClosedAt))
        {

        }
    }
}
