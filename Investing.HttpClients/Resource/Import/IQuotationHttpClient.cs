using Investing.Core.Domain.Entities;
using Investing.HttpClients.Core.ResponseModels;
using Investing.HttpClients.Resource.Import.RequestModels;

namespace Investing.HttpClients.Resource.Import
{
    public interface IQuotationHttpClient
    {
        Task<ResponseModel<Product>> ImportAsync(ImportBcsQuotationModel model);
    }
}
