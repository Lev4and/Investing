using Investing.HttpClients.Bcs;
using Investing.HttpClients.BcsApi;

namespace Investing.HttpClients
{
    public class HttpContext : IHttpContext
    {
        public IBcsHttpContext Bcs => new BcsHttpContext();

        public IBcsApiHttpContext BcsApi => new BcsApiHttpContext();
    }
}
