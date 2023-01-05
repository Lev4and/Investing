using Investing.HttpClients.Bcs;
using Investing.HttpClients.BcsApi;
using Investing.HttpClients.BcsExpress;
using Investing.HttpClients.Resource;

namespace Investing.HttpClients
{
    public interface IHttpContext
    {
        IBcsHttpContext Bcs { get; }

        IBcsApiHttpContext BcsApi { get; }

        IResourceHttpContext Resource { get; }

        IBcsExpressHttpContext BcsExpress { get; }
    }
}
