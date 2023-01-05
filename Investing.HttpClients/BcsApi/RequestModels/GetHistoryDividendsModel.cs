namespace Investing.HttpClients.BcsApi.RequestModels
{
    public class GetHistoryDividendsModel
    {
        public string IsinCode { get; }

        public GetHistoryDividendsModel(string isinCode)
        {
            if (string.IsNullOrEmpty(isinCode)) throw new ArgumentNullException(nameof(isinCode));

            IsinCode = isinCode;
        }
    }
}
