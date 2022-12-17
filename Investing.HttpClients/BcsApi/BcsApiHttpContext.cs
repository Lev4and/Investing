namespace Investing.HttpClients.BcsApi
{
    public class BcsApiHttpContext : IBcsApiHttpContext
    {
        public IPartnerHttpClient Partner => new PartnerHttpClient();

        public IUdfDataFeedHttpClient UdfDataFeed => new UdfDataFeedHttpClient();
    }
}
