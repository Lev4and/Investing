using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public interface IPartnerHttpClient
    {
        Task<ResponseModel<PartnerQuotations>> GetPartnerQuotationsAsync(int offset, string partnerToken);
    }
}
