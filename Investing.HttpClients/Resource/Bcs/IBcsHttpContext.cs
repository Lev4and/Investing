namespace Investing.HttpClients.Resource.Bcs
{
    public interface IBcsHttpContext
    {
        IPartnersHttpClient Partners { get; }

        IDividendsHttpClient Dividends { get; }

        IQuotationsHttpClient Quotations { get; }
    }
}
