using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public interface IDividendsCalendarHttpClient
    {
        Task<ResponseModel<HistoryDividends>> GetHistoryDividendsAsync(string isinCode);
    }
}
