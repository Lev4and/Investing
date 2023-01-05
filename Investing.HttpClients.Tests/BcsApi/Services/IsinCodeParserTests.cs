using Investing.HttpClients.BcsApi.Services;

namespace Investing.HttpClients.Tests.BcsApi.Services
{
    public class IsinCodeParserTests
    {
        [Fact]
        public void Parse_WithNullContentParam_ThrowException()
        {
            var action = () => { IsinCodeParser.Parse(null); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Parse_WithEmptyContentParam_ThrowException()
        {
            var action = () => { IsinCodeParser.Parse(""); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Parse_WithContentParam_ReturnCorrectMatchedResult()
        {
            var content = "\"isinCode\":\"RU0009024277\"";

            var result = IsinCodeParser.Parse(content);

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            Assert.Equal("RU0009024277", result);
        }

        [Fact]
        public void Parse_WithContentParamWithoutIsinCode_ReturnNullResult()
        {
            var content = "\\\"isinCode\\\":";

            var result = IsinCodeParser.Parse(content);

            Assert.Null(result);
        }
    }
}
