namespace Investing.HttpClients.BcsApi
{
    public interface IBcsApiHttpContext
    {
        IPartnerHttpClient Partner { get; }

        IUdfDataFeedHttpClient UdfDataFeed { get; }
    }
}
