namespace Investing.HttpClients.Resource.Import
{
    public interface IImportHttpContext
    {
        IProductHttpClient Product { get; }

        IQuotationHttpClient Quotation { get; }
    }
}
