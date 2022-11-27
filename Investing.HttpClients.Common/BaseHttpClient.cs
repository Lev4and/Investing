using Investing.HttpClients.Common.Builders;
using Investing.HttpClients.Common.Extensions;
using Investing.HttpClients.Common.HttpRequestHandlers;
using Investing.HttpClients.Common.ResponseModels;

namespace Investing.HttpClients.Common
{
    public class BaseHttpClient : HttpClient
    {
        public BaseHttpClient() : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {

        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            BaseAddress = new Uri(uri);
        }

        public async Task<ResponseModel<T>> GetAsync<T>(string uri, CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => GetAsync(uri, cancellationToken));
        }

        public async Task<ResponseModel<T>> PostAsync<T>(string uri, object content, CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => PostAsync(uri, content.ToStringContent(), cancellationToken));
        }

        public async Task<ResponseModel<T>> PutAsync<T>(string uri, object content, CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => PutAsync(uri, content.ToStringContent(), cancellationToken));
        }

        public async Task<ResponseModel<T>> DeleteAsync<T>(string uri, CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => DeleteAsync(uri, cancellationToken));
        }
    }
}
