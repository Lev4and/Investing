using Investing.HttpClients.Core.ResponseModels;
using System.Net;

namespace Investing.HttpClients.Core
{
    public interface IHttpResponseMaper
    {
        ResponseModel<TResult> Map<TResult>(string? responseContent, HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
