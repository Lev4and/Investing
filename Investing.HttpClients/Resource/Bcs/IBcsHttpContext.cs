namespace Investing.HttpClients.Resource.Bcs
{
    public interface IBcsHttpContext
    {
        IPartnersHttpClient Partners { get; }

        IQuotationsHttpClient Quotations { get; }
    }
}
