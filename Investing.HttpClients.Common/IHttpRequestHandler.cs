using Investing.HttpClients.Common.ResponseModels;

namespace Investing.HttpClients.Common
{
    public interface IHttpRequestHandler<T>
    {
        IHttpResponseReader Reader { get; }

        Task<ResponseModel<T>> HandleAsync(Func<Task<HttpResponseMessage>> request);
    }
}
