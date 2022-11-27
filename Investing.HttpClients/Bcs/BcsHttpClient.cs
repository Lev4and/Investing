using Investing.HttpClients.Common;

namespace Investing.HttpClients.Bcs
{
    public class BcsHttpClient : BaseHttpClient
    {
        public BcsHttpClient(string path) : base($"{BcsRoutes.Protocol}://{BcsRoutes.Domain}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            UseHeaders(BcsHeaders.DefaultHeaders);
        }
    }
}
