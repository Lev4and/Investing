namespace Investing.HttpClients.BcsApi.RequestModels
{
    public class GetHistoryQuotationsModel
    {
        public long ToUnix { get; }

        public long FromUnix { get; }

        public string SecurCode { get; }

        public string ClassCode { get; }

        public QuotationResolution Resolution { get; }

        public GetHistoryQuotationsModel(string securCode, string classCode, DateTime from, DateTime to, QuotationResolution resolution)
        {
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));
            if (string.IsNullOrEmpty(classCode)) throw new ArgumentNullException(nameof(classCode));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            ToUnix = DateTimeOffset.Parse(to.ToString()).ToUnixTimeMilliseconds();
            FromUnix = DateTimeOffset.Parse(from.ToString()).ToUnixTimeMilliseconds();
            SecurCode = securCode;
            ClassCode = classCode;
            Resolution = resolution;
        }
    }
}
