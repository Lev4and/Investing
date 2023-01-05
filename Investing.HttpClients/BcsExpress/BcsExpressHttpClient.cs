using Investing.HttpClients.Core;

namespace Investing.HttpClients.BcsExpress
{
    public class BcsExpressHttpClient : BaseHttpClient
    {
        public BcsExpressHttpClient(string path) : base($"{BcsExpressRoutes.Protocol}://{BcsExpressRoutes.Domain}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
        }
    }
}
