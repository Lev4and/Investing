namespace Investing.HttpClients.BcsApi.RequestModels
{
    public class GetPartnerQuotationsModel
    {
        public int Limit { get; }

        public int Offset { get; }

        public string SortMode { get; }

        public PartnerQuotationsGraphType GraphType { get; }

        public PartnerQuotationsSortField SortField { get; }

        public GetPartnerQuotationsModel(int offset)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            Limit = 20;
            Offset = offset - 1;
            SortMode = PartnerQuotationsSortMode.Ascending;
            GraphType = PartnerQuotationsGraphType.Default;
            SortField = PartnerQuotationsSortField.Name;
        }
    }
}
