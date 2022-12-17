namespace Investing.HttpClients.Bcs
{
    public class BcsHttpContext : IBcsHttpContext
    {
        public IAssetsHttpClient Assets => new AssetsHttpClient();
    }
}
