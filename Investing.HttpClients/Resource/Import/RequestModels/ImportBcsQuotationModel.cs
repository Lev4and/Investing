using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.HttpClients.Resource.Import.RequestModels
{
    public class ImportBcsQuotationModel
    {
        public PartnerBase Partner { get; set; }

        public HistoryQuotations HistoryQuotations { get; set; }
    }
}
