using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public class DividendsCalendarHttpClient : BcsApiHttpClient, IDividendsCalendarHttpClient
    {
        public DividendsCalendarHttpClient() : base(BcsApiRoutes.DividendsCalendarPath)
        {

        }

        public async Task<ResponseModel<HistoryDividends>> GetHistoryDividendsAsync(string isinCode)
        {
            if (string.IsNullOrEmpty(isinCode)) throw new ArgumentNullException(nameof(isinCode));

            return await GetAsync<HistoryDividends>(BcsApiRoutes.DividendsCalendarDividendQuery.Inject(
                new GetHistoryDividendsModel(isinCode)));
        }
    }
}
