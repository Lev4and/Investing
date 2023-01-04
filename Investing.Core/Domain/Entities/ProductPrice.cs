namespace Investing.Core.Domain.Entities
{
    public class ProductPrice : LinkedList<Ohlc>
    {
        public ProductPrice(IEnumerable<Ohlc> prices) : base(prices.OrderBy(price => price.ClosedAt))
        {

        }
    }
}
