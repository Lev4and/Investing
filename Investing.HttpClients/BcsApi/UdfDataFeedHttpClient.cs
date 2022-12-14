using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public class UdfDataFeedHttpClient : BcsApiHttpClient, IUdfDataFeedHttpClient
    {
        public UdfDataFeedHttpClient() : base(BcsApiRoutes.UdfDataFeedPath)
        {

        }

        public async Task<ResponseModel<HistoryQuotations>> GetHistoryQuotationsAsync(GetHistoryQuotationsModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<HistoryQuotations>(BcsApiRoutes.UdfDataFeedHistoryQuotationsQuery.Inject(model));
        }
    }
}
