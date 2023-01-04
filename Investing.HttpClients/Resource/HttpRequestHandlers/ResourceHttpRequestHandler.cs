using Investing.HttpClients.Core;
using Investing.HttpClients.Core.HttpRequestHandlers;
using Investing.HttpClients.Core.HttpResponseMapers;

namespace Investing.HttpClients.Resource.HttpRequestHandlers
{
    public class ResourceHttpRequestHandler : BaseHttpRequestHandler
    {
        public override IHttpResponseMaper Maper => new AutoWrapperHttpResponseMaper();
    }
}
