using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.HttpClients.Facades
{
    public interface IBcsFacade
    {
        Task<PartnerQuotations?> GetPartnerQuotationsAsync(int offset);

        Task<HistoryQuotations?> GetHistoryQuotationsAsync(GetHistoryQuotationsModel model);
    }
}
