using Investing.HttpClients.Bcs;
using Investing.HttpClients.BcsApi;

namespace Investing.HttpClients
{
    public class HttpContext
    {
        public BcsHttpContext Bcs => new BcsHttpContext();

        public BcsApiHttpContext BcsApi => new BcsApiHttpContext();
    }
}
