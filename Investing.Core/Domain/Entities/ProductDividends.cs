namespace Investing.Core.Domain.Entities
{
    public class ProductDividends : LinkedList<Dividend>
    {
        public ProductDividends(IEnumerable<Dividend> dividends) : base(dividends.OrderByDescending(dividend => 
            dividend.ClosingDate))
        {

        }
    }
}
