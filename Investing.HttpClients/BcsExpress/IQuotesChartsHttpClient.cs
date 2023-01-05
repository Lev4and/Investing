namespace Investing.HttpClients.BcsExpress
{
    public interface IQuotesChartsHttpClient
    {
        Task<string> GetDividendsHtmlPageAsync(string securCode);
    }
}
