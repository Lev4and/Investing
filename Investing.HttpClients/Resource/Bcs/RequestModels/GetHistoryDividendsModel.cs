namespace Investing.HttpClients.Resource.Bcs.RequestModels
{
    public class GetHistoryDividendsModel
    {
        public string SecurCode { get; }

        public GetHistoryDividendsModel(string securCode)
        {
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));

            SecurCode = securCode;
        }
    }
}
