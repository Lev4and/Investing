namespace Investing.HttpClients.Resource.Bcs
{
    public class BcsHttpContext : IBcsHttpContext
    {
        public IPartnersHttpClient Partners => new PartnersHttpClient();

        public IDividendsHttpClient Dividends => new DividendsHttpClient();

        public IQuotationsHttpClient Quotations => new QuotationsHttpClient();
    }
}
