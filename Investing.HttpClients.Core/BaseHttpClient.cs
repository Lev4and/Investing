using Investing.HttpClients.Core.Builders;
using Investing.HttpClients.Core.Extensions;
using Investing.HttpClients.Core.HttpRequestHandlers;
using Investing.HttpClients.Core.ResponseModels;

namespace Investing.HttpClients.Core
{
    public class BaseHttpClient : HttpClient
    {
        public BaseHttpClient() : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {

        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            BaseAddress = new Uri(uri);
        }

        public async Task<ResponseModel<T>> GetAsync<T>(string uri, CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => GetAsync(uri, cancellationToken));
        }

        public async Task<ResponseModel<T>> PostAsync<T>(string uri, object content, 
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => PostAsync(uri, content.ToStringContent(), 
                cancellationToken));
        }

        public async Task<ResponseModel<T>> PutAsync<T>(string uri, object content, 
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => PutAsync(uri, content.ToStringContent(), 
                cancellationToken));
        }

        public async Task<ResponseModel<T>> DeleteAsync<T>(string uri, CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await new JsonHttpRequestHandler<T>().HandleAsync(() => DeleteAsync(uri, cancellationToken));
        }

        public void UseHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            DefaultRequestHeaders.Clear();

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void OverrideHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Remove(header.Key);
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
