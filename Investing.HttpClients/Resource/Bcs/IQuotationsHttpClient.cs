using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Resource.Bcs
{
    public interface IQuotationsHttpClient
    {
        Task<ResponseModel<HistoryQuotations>> GetQuotationsAsync(GetHistoryQuotationsModel model);
    }
}
