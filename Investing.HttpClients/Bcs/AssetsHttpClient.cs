using Investing.Core.Extensions;

namespace Investing.HttpClients.Bcs
{
    public class AssetsHttpClient : BcsHttpClient, IAssetsHttpClient
    {
        public AssetsHttpClient() : base(BcsRoutes.AssetsPath)
        {

        }

        public async Task<string> GetScriptJsAsync(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            return await GetStringAsync(BcsRoutes.AssetsScriptJsQuery.Inject(new { path }));
        }

        public async Task<string> GetScriptJsMarketsJs()
        {
            return await GetScriptJsAsync(BcsRoutes.AssetsScriptJsQueryMarketsJsPath);
        }
    }
}
