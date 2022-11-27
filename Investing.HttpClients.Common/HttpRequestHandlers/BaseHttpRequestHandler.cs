using Investing.HttpClients.Common.HttpResponseReaders;
using Investing.HttpClients.Common.ResponseModels;

namespace Investing.HttpClients.Common.HttpRequestHandlers
{
    public abstract class BaseHttpRequestHandler<T> : IHttpRequestHandler<T>
    {
        public virtual IHttpResponseReader Reader => new BaseHttpResponseReader();

        public async Task<ResponseModel<T>> HandleAsync(Func<Task<HttpResponseMessage>> request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            try
            {
                var response = await request.Invoke();
                var responseContent = await Reader.ReadAsync(response);

                return new ResponseModel<T>(ToResult(responseContent), response);
            }
            catch (Exception ex)
            {
                return new ResponseModel<T>(default, ex.Message, code: null);
            }
        }

        protected abstract T? ToResult(string responseContent);
    }
}
