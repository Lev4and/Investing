using Investing.HttpClients.Bcs;
using Investing.HttpClients.BcsApi;

namespace Investing.HttpClients
{
    public interface IHttpContext
    {
        IBcsHttpContext Bcs { get; }

        IBcsApiHttpContext BcsApi { get; }
    }
}
