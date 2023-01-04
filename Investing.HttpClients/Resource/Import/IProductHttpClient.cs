using Investing.Core.Domain.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Resource.Import
{
    public interface IProductHttpClient
    {
        Task<ResponseModel<Product>> ImportAsync(PartnerBase partner);
    }
}
