namespace Investing.HttpClients.BcsApi
{
    public class BcsApiHttpContext
    {
        public PartnerHttpClient Partner => new PartnerHttpClient();

        public UdfDataFeedHttpClient UdfDataFeed => new UdfDataFeedHttpClient();
    }
}
