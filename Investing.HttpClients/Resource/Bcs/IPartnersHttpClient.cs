using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Resource.Bcs
{
    public interface IPartnersHttpClient
    {
        Task<ResponseModel<PartnerQuotations>> GetPartnersAsync(int offset = 0);
    }
}
