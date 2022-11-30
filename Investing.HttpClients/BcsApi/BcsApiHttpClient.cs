using Investing.HttpClients.Core;

namespace Investing.HttpClients.BcsApi
{
    public class BcsApiHttpClient : BaseHttpClient
    {
        public BcsApiHttpClient(string path) : base($"{BcsApiRoutes.Protocol}://{BcsApiRoutes.Domain}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            UseHeaders(BcsApiHeaders.DefaultHeaders);
        }
    }
}
