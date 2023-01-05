namespace Investing.HttpClients.BcsExpress.RequestModels
{
    public class GetDividendsHtmlPageModel
    {
        public string SecurCode { get; }

        public GetDividendsHtmlPageModel(string securCode)
        {
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));

            SecurCode = securCode;
        }
    }
}
