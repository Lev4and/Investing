using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Common.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public class UdfDataFeedHttpClient : BcsApiHttpClient
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
