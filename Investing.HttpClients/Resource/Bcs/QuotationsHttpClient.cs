using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Resource.Bcs
{
    public class QuotationsHttpClient : ResourceHttpClient, IQuotationsHttpClient
    {
        public QuotationsHttpClient() : base($"{BcsRoutes.BcsArea}/{BcsRoutes.BcsQuotationsPath}")
        {

        }

        public async Task<ResponseModel<HistoryQuotations>> GetQuotationsAsync(GetHistoryQuotationsModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<HistoryQuotations>(BcsRoutes.BcsQuotationsQuery.Inject(model));
        }
    }
}
