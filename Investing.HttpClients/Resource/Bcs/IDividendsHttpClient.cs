using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Resource.Bcs
{
    public interface IDividendsHttpClient
    {
        Task<ResponseModel<HistoryDividends>> GetHistoryDividendsAsync(string securCode);
    }
}
