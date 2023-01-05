namespace Investing.HttpClients.BcsExpress
{
    public interface IBcsExpressHttpContext
    {
        IQuotesChartsHttpClient QuotesCharts { get; }
    }
}
