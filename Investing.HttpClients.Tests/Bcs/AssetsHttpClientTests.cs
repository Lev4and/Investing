namespace Investing.HttpClients.Tests.Bcs
{
    public class AssetsHttpClientTests
    {
        private readonly HttpContext _context;

        public AssetsHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetScriptJsAsync_WithNullPathParam_ThrowException()
        {
            var action = async () => { await _context.Bcs.Assets.GetScriptJsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetScriptJsAsync_WithEmptyPathParam_ThrowException()
        {
            var action = async () => { await _context.Bcs.Assets.GetScriptJsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetScriptJsAsync_WithPathParam_ReturnScriptJsContent()
        {
            var scriptJsContent = await _context.Bcs.Assets.GetScriptJsAsync("markets/markets.min.js");

            Assert.NotNull(scriptJsContent);
            Assert.NotEmpty(scriptJsContent);
        }

        [Fact]
        public async Task GetScriptJsMarketsJs_ReturnScriptJsContent()
        {
            var scriptJsContent = await _context.Bcs.Assets.GetScriptJsMarketsJs();

            Assert.NotNull(scriptJsContent);
            Assert.NotEmpty(scriptJsContent);
        }
    }
}
