using Investing.HttpClients.Core;
using Investing.HttpClients.Resource.HttpRequestHandlers;

namespace Investing.HttpClients.Resource
{
    public class ResourceHttpClient : BaseHttpClient
    {
        protected override IHttpRequestHandler HttpRequestHandler => new ResourceHttpRequestHandler();

        public ResourceHttpClient(string path) : base($"{ResourceRoutes.Protocol}://{ResourceRoutes.Domain}/" +
            $"{Environment.GetEnvironmentVariable("ASPNETCORE_BACKEND_PATH_URL") ?? "resource"}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
        }
    }
}
