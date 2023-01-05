using Investing.HttpClients.Bcs;
using Investing.HttpClients.BcsApi;
using Investing.HttpClients.BcsExpress;
using Investing.HttpClients.Resource;

namespace Investing.HttpClients
{
    public class HttpContext : IHttpContext
    {
        public IBcsHttpContext Bcs => new BcsHttpContext();

        public IBcsApiHttpContext BcsApi => new BcsApiHttpContext();

        public IResourceHttpContext Resource => new ResourceHttpContext();

        public IBcsExpressHttpContext BcsExpress => new BcsExpressHttpContext();
    }
}
