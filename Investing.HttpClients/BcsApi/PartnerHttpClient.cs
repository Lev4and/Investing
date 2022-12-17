using Investing.Core.Extensions;
using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.BcsApi
{
    public class PartnerHttpClient : BcsApiHttpClient, IPartnerHttpClient
    {
        public PartnerHttpClient() : base(BcsApiRoutes.PartnerPath)
        {

        }

        public async Task<ResponseModel<PartnerQuotations>> GetPartnerQuotationsAsync(int offset, string partnerToken)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
            if (string.IsNullOrEmpty(partnerToken)) throw new ArgumentNullException(nameof(partnerToken));

            OverrideHeaders(new Dictionary<string, string>() { { "partner-token", partnerToken } });

            return await GetAsync<PartnerQuotations>(BcsApiRoutes.PartnerQuotationsQuery
                .Inject(new GetPartnerQuotationsModel(offset)));
        }
    }
}
