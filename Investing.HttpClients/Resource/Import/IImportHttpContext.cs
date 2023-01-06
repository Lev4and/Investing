namespace Investing.HttpClients.Resource.Import
{
    public interface IImportHttpContext
    {
        IProductHttpClient Product { get; }

        IDividendHttpClient Dividend { get; }

        IQuotationHttpClient Quotation { get; }
    }
}
