using Newtonsoft.Json;

namespace Investing.HttpClients.Core.HttpRequestHandlers
{
    public class JsonHttpRequestHandler<T> : BaseHttpRequestHandler<T>
    {
        protected override T? ToResult(string responseContent)
        {
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
