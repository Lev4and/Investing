using Investing.HttpClients.Core.ResponseModels;
using Newtonsoft.Json;
using System.Net;

namespace Investing.HttpClients.Core.HttpResponseMapers
{
    public class JsonHttpResponseMaper : IHttpResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return new ResponseModel<TResult>(JsonConvert.DeserializeObject<TResult>(responseContent), statusCode);
        }
    }
}
