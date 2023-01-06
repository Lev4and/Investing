using Investing.Core.Domain.Entities;
using Investing.HttpClients.Core.ResponseModels;
using Investing.HttpClients.Resource.Import.RequestModels;

namespace Investing.HttpClients.Resource.Import
{
    public class DividendHttpClient : ResourceHttpClient, IDividendHttpClient
    {
        public DividendHttpClient() : base($"{ImportRoutes.ImportArea}/{ImportRoutes.ImportDividendPath}")
        {

        }

        public async Task<ResponseModel<Product>> ImportAsync(ImportBcsDividendsModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await PostAsync<Product>("", model);
        }
    }
}
