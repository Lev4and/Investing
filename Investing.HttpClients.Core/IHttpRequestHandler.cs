using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Core
{
    public interface IHttpRequestHandler<T>
    {
        IHttpResponseReader Reader { get; }

        Task<ResponseModel<T>> HandleAsync(Func<Task<HttpResponseMessage>> request);
    }
}
