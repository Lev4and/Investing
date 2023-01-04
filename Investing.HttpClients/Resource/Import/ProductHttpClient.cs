using Investing.Core.Domain.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Resource.Import
{
    public class ProductHttpClient : ResourceHttpClient, IProductHttpClient
    {
        public ProductHttpClient() : base($"{ImportRoutes.ImportArea}/{ImportRoutes.ImportProductPath}")
        {

        }

        public async Task<ResponseModel<Product>> ImportAsync(PartnerBase partner)
        {
            if (partner == null) throw new ArgumentNullException(nameof(partner));

            return await PostAsync<Product>("", partner);
        }
    }
}
