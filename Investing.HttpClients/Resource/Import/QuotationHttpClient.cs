using Investing.Core.Domain.Entities;
using Investing.HttpClients.Core.ResponseModels;
using Investing.HttpClients.Resource.Import.RequestModels;

namespace Investing.HttpClients.Resource.Import
{
    public class QuotationHttpClient : ResourceHttpClient, IQuotationHttpClient
    {
        public QuotationHttpClient() : base($"{ImportRoutes.ImportArea}/{ImportRoutes.ImportQuotationPath}")
        {

        }

        public async Task<ResponseModel<Product>> ImportAsync(ImportBcsQuotationModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await PostAsync<Product>("", model);
        }
    }
}
