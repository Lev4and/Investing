using Investing.HttpClients.BcsApi.RequestModels;
using System.Net;

namespace Investing.HttpClients.Tests.BcsApi
{
    public class UdfDataFeedHttpClientTests
    {
        private readonly HttpContext _context;

        public UdfDataFeedHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetHistoryQuotationsAsync_WithNullModelParam_ThrowException()
        {
            var action = async () => { await _context.BcsApi.UdfDataFeed.GetHistoryQuotationsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetHistoryQuotationsAsync_WithInvalidModelParam_ReturnNullResult()
        {
            var result = await _context.BcsApi.UdfDataFeed.GetHistoryQuotationsAsync(new GetHistoryQuotationsModel(
                "????", "????", DateTime.UtcNow.AddYears(-5), DateTime.UtcNow, QuotationResolution.Minute));

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Null(result.Result.OpenValues);
            Assert.Equal(HttpStatusCode.OK, result.Code);
        }

        [Fact]
        public async Task GetHistoryQuotationsAsync_WithCorrectModelParam_ReturnNotEmptyResult()
        {
            var result = await _context.BcsApi.UdfDataFeed.GetHistoryQuotationsAsync(new GetHistoryQuotationsModel(
                "SBER", "TQBR", DateTime.UtcNow.AddYears(-5), DateTime.UtcNow, QuotationResolution.Minute));

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.NotEmpty(result.Result.OpenValues);
            Assert.Equal(result.Result.OpenValues.Count, result.Result.GetQuotations().Count());
            Assert.Equal(HttpStatusCode.OK, result.Code);
        }
    }
}
