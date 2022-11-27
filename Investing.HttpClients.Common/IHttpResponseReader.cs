namespace Investing.HttpClients.Common
{
    public interface IHttpResponseReader
    {
        Task<string> ReadAsync(HttpResponseMessage response);
    }
}
