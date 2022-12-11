namespace Investing.HttpClients.BcsApi
{
    public class BcsApiRoutes
    {
        public const string Protocol = "http";

        public const string Domain = "api.bcs.ru";

        public const string PartnerPath = "partner/v2/";

        public const string PartnerQuotationsQuery = "quotations?portfolio_ids=113&portfolio_ids=114&portfolio_ids=115&" +
            "portfolio_ids=116&portfolio_ids=117&sorting={SortField}&sorting_order={SortMode}&graph_type={GraphType}&" +
            "limit={Limit}&last_value={Offset}";

        public const string UdfDataFeedPath = "udfdatafeed/v1/";

        public const string UdfDataFeedHistoryQuotationsQuery = "history?symbol={SecurCode}&resolution={Resolution}&" +
            "classcode={ClassCode}&from={FromUnix}&to={ToUnix}";
    }
}
