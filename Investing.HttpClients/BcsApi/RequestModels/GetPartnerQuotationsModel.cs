namespace Investing.HttpClients.BcsApi.RequestModels
{
    public class GetPartnerQuotationsModel
    {
        public int Limit { get; }

        public int Offset { get; }

        public int GraphType { get; }

        public int SortField { get; }

        public string SortMode { get; }

        public GetPartnerQuotationsModel(int offset)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            Limit = 20;
            Offset = offset - 1;
            GraphType = (int)PartnerQuotationsGraphType.Default;
            SortField = (int)PartnerQuotationsSortField.Name;
            SortMode = PartnerQuotationsSortMode.Ascending;
        }
    }
}
