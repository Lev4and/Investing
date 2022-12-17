using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.BcsApi.Services;

namespace Investing.HttpClients.Facades
{
    public class BcsFacade : IBcsFacade
    {
        private readonly IHttpContext _httpContext;

        public BcsFacade(IHttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public async Task<PartnerQuotations?> GetPartnerQuotationsAsync(int offset)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var marketsJs = await _httpContext.Bcs.Assets.GetScriptJsMarketsJs();
            var token = PartnerTokenParser.Parse(marketsJs) ?? "";

            var result = await _httpContext.BcsApi.Partner.GetPartnerQuotationsAsync(offset, token);

            return result.Result;
        }

        public async Task<HistoryQuotations?> GetHistoryQuotationsAsync(GetHistoryQuotationsModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var result = await _httpContext.BcsApi.UdfDataFeed.GetHistoryQuotationsAsync(model);

            return result.Result;
        }
    }
}
