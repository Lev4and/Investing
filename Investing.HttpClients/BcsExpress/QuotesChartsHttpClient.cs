using Investing.Core.Extensions;
using Investing.HttpClients.BcsExpress.RequestModels;

namespace Investing.HttpClients.BcsExpress
{
    public class QuotesChartsHttpClient : BcsExpressHttpClient, IQuotesChartsHttpClient
    {
        public QuotesChartsHttpClient() : base(BcsExpressRoutes.QuotesChartsPath)
        {

        }

        public async Task<string> GetDividendsHtmlPageAsync(string securCode)
        {
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));

            return await GetStringAsync(BcsExpressRoutes.QuotesChartsDividendsQuery.Inject(
                new GetDividendsHtmlPageModel(securCode)));
        }
    }
}
