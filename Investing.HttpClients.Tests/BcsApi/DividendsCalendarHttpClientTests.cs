using Investing.HttpClients.BcsApi;
using System.Net;

namespace Investing.HttpClients.Tests.BcsApi
{
    public class DividendsCalendarHttpClientTests
    {
        private readonly IDividendsCalendarHttpClient _httpClient;

        public DividendsCalendarHttpClientTests()
        {
            _httpClient = new DividendsCalendarHttpClient();
        }

        [Fact]
        public async Task GetHistoryDividendsAsync_WithNullParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetHistoryDividendsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetHistoryDividendsAsync_WithEmptyParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetHistoryDividendsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetHistoryDividendsAsync_WithNotCorrectParam_ReturnNullResult()
        {
            var response = await _httpClient.GetHistoryDividendsAsync("???");

            Assert.NotNull(response);
            Assert.Null(response.Result);
            Assert.Equal(HttpStatusCode.NotFound, response.Code);
        }

        [Fact]
        public async Task GetHistoryDividendsAsync_WithCorrectParam_ReturnNotNullResult()
        {
            var response = await _httpClient.GetHistoryDividendsAsync("RU0009024277");

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotNull(response.Result.Dividends);
            Assert.NotEmpty(response.Result.Dividends);
            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
