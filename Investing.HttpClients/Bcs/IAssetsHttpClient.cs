namespace Investing.HttpClients.Bcs
{
    public interface IAssetsHttpClient
    {
        Task<string> GetScriptJsAsync(string path);

        Task<string> GetScriptJsMarketsJs();
    }
}
