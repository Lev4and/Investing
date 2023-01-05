using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;
using Investing.HttpClients.Resource.Bcs.RequestModels;

namespace Investing.HttpClients.Resource.Bcs
{
    public class DividendsHttpClient : ResourceHttpClient, IDividendsHttpClient
    {
        public DividendsHttpClient() : base(BcsRoutes.BcsDividendsPath)
        {

        }

        public async Task<ResponseModel<HistoryDividends>> GetHistoryDividendsAsync(string securCode)
        {
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));

            return await GetAsync<HistoryDividends>(BcsRoutes.BcsDividendsHistoryQuery.Inject(
                new GetHistoryDividendsModel(securCode)));
        }
    }
}
