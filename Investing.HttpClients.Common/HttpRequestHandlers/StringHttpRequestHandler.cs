namespace Investing.HttpClients.Common.HttpRequestHandlers
{
    public class StringHttpRequestHandler : BaseHttpRequestHandler<string>
    {
        protected override string? ToResult(string responseContent)
        {
            return responseContent;
        }
    }
}
