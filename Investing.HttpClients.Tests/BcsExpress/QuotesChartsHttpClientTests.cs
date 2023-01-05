using Investing.HttpClients.BcsExpress;

namespace Investing.HttpClients.Tests.BcsExpress
{
    public class QuotesChartsHttpClientTests
    {
        private readonly IQuotesChartsHttpClient _httpClient;

        public QuotesChartsHttpClientTests()
        {
            _httpClient = new QuotesChartsHttpClient();
        }

        [Fact]
        public async Task GetDividendsHtmlPageAsync_WithNullParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetDividendsHtmlPageAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetDividendsHtmlPageAsync_WithEmptyParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetDividendsHtmlPageAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetDividendsHtmlPageAsync_WithNotExistsValueParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetDividendsHtmlPageAsync("AAAA"); };

            await Assert.ThrowsAsync<HttpRequestException>(action);
        }

        [Fact]
        public async Task GetDividendsHtmlPageAsync_WithExistsValueParam_ReturnDividendsHtmlPage()
        {
            var dividendsHtmlPage = await _httpClient.GetDividendsHtmlPageAsync("LKOH");

            Assert.NotNull(dividendsHtmlPage);
            Assert.NotEmpty(dividendsHtmlPage);
        }
    }
}
