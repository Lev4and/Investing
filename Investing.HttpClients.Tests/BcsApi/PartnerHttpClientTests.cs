using Investing.HttpClients.BcsApi.Services;
using System.Net;

namespace Investing.HttpClients.Tests.BcsApi
{
    public class PartnerHttpClientTests
    {
        private readonly HttpContext _context;

        public PartnerHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_WithNegativeOffsetParam_ThrowException()
        {
            var action = async () => { await _context.BcsApi.Partner.GetPartnerQuotationsAsync(-1, ""); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_WithNullPartnerTokenParam_ThrowException()
        {
            var action = async () => { await _context.BcsApi.Partner.GetPartnerQuotationsAsync(0, null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_WithEmptyPartnerTokenParam_ThrowException()
        {
            var action = async () => { await _context.BcsApi.Partner.GetPartnerQuotationsAsync(0, ""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_WithHugeOffsetParam_ReturnEmptyResult()
        {
            var offset = int.MaxValue;
            var partnerToken = PartnerTokenParser.Parse(await _context.Bcs.Assets.GetScriptJsMarketsJs());

            var result = await _context.BcsApi.Partner.GetPartnerQuotationsAsync(offset, partnerToken);

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.NotNull(result.Result.Partners);
            Assert.Empty(result.Result.Partners);
            Assert.Equal(HttpStatusCode.OK, result.Status.Code);
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_WithCorrectParams_ReturnPartnerQuotations()
        {
            var offset = 0;
            var partnerToken = PartnerTokenParser.Parse(await _context.Bcs.Assets.GetScriptJsMarketsJs());

            var result = await _context.BcsApi.Partner.GetPartnerQuotationsAsync(offset, partnerToken);

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.NotNull(result.Result.Partners);
            Assert.NotEmpty(result.Result.Partners);
            Assert.Equal(HttpStatusCode.OK, result.Status.Code);
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_WithCorrectOffsetAndInvalidPartnerTokenParam_ReturnNullResult()
        { 
            var offset = 0;
            var partnerToken = Guid.NewGuid().ToString().ToUpper();

            var result = await _context.BcsApi.Partner.GetPartnerQuotationsAsync(offset, partnerToken);

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Null(result.Result.Partners);
            Assert.Equal(HttpStatusCode.Unauthorized, result.Status.Code);
        }

        [Fact]
        public async Task GetPartnerQuotationsAsync_SuccessfullyNavigateToAllPages()
        {
            var partnerToken = PartnerTokenParser.Parse(await _context.Bcs.Assets.GetScriptJsMarketsJs());
            var firstPage = await _context.BcsApi.Partner.GetPartnerQuotationsAsync(0, partnerToken);

            if (firstPage.Result != null)
            {
                for (var i = 0; i <= firstPage.Result.Total; i+= 20)
                {
                    var result = await _context.BcsApi.Partner.GetPartnerQuotationsAsync(i, partnerToken);

                    if (result?.Result?.Partners == null) 
                        Assert.Fail("Fail by reason: \"result.Result.Partners\" is null or empty");
                }
            }
            else Assert.Fail("Fail by reason: \"firstPage.Result\" is null");
        }
    }
}
