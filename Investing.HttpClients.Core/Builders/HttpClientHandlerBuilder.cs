using System.Net;
using SslProtocols = System.Security.Authentication.SslProtocols;

namespace Investing.HttpClients.Core.Builders
{
    public class HttpClientHandlerBuilder
    {
        private readonly HttpClientHandler _httpClientHandler = new HttpClientHandler();

        public HttpClientHandlerBuilder WithSslProtocols()
        {
            _httpClientHandler.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 |
                SslProtocols.Tls12;

            return this;
        }

        public HttpClientHandlerBuilder UseCertificateCustomValidation()
        {
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            return this;
        }

        public HttpClientHandlerBuilder WithAllowAutoRedirect()
        {
            _httpClientHandler.AllowAutoRedirect = true;

            return this;
        }

        public HttpClientHandlerBuilder WithAutomaticDecompression()
        {
            _httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | 
                DecompressionMethods.Brotli;

            return this;
        }

        public HttpClientHandler Build()
        {
            return _httpClientHandler;
        }
    }
}
