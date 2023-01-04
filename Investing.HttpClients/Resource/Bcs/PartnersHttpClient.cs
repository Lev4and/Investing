using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;
using Investing.HttpClients.Resource.Bcs.RequestModels;

namespace Investing.HttpClients.Resource.Bcs
{
    public class PartnersHttpClient : ResourceHttpClient, IPartnersHttpClient
    {
        public PartnersHttpClient() : base($"{BcsRoutes.BcsArea}/{BcsRoutes.BcsPartnersPath}")
        {

        }

        public async Task<ResponseModel<PartnerQuotations>> GetPartnersAsync(int offset = 0)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            return await GetAsync<PartnerQuotations>(BcsRoutes.BcsPartnersQuery.Inject(new GetPartnersModel(offset)));
        }
    }
}
