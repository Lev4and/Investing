using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public interface IUdfDataFeedHttpClient
    {
        Task<ResponseModel<HistoryQuotations>> GetHistoryQuotationsAsync(GetHistoryQuotationsModel model);
    }
}
