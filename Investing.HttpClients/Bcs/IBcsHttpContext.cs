namespace Investing.HttpClients.Bcs
{
    public interface IBcsHttpContext
    {
        IAssetsHttpClient Assets { get; }
    }
}
