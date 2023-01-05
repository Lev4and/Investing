namespace Investing.HttpClients.BcsExpress
{
    public class BcsExpressHttpContext : IBcsExpressHttpContext
    {
        public IQuotesChartsHttpClient QuotesCharts => new QuotesChartsHttpClient();
    }
}
