using Investing.HttpClients.BcsApi.Services;

namespace Investing.HttpClients.Tests.BcsApi.Services
{
    public class PartnerTokenParserTests
    {
        [Fact]
        public void Parse_WithNullContentParam_ThrowException()
        {
            var action = () => {  PartnerTokenParser.Parse(null); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Parse_WithEmptyContentParam_ThrowException()
        {
            var action = () => { PartnerTokenParser.Parse(""); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Parse_WithContentParam_ReturnCorrectMatchedResult()
        {
            var content = "token:\"A5264D52-1510-4E42-8E90-E729FF405646\"";

            var result = PartnerTokenParser.Parse(content);

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            Assert.Equal("A5264D52-1510-4E42-8E90-E729FF405646", result);
        }

        [Fact]
        public void Parse_WithContentParamWithoutToken_ReturnNullResult()
        {
            var content = "token:";

            var result = PartnerTokenParser.Parse(content);

            Assert.Null(result);
        }
    }
}
