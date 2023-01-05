namespace Investing.HttpClients.Resource.Bcs
{
    public class BcsRoutes
    {
        public const string BcsArea = "api/bcs";

        public const string BcsPartnersPath = "partners";

        public const string BcsPartnersQuery = "?offset={Offset}";

        public const string BcsQuotationsPath = "quotations";

        public const string BcsQuotationsQuery = "{SecurCode}/{ClassCode}?from={From}&to={To}&" +
            "resolution={Resolution}";

        public const string BcsDividendsPath = "dividends";

        public const string BcsDividendsHistoryQuery = "{SecurCode}";
    }
}
