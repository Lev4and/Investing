using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.HttpClients.Resource.Import.RequestModels
{
    public class ImportBcsDividendsModel
    {
        public PartnerBase Partner { get; set; }

        public HistoryDividends HistoryDividends { get; set; }
    }
}
