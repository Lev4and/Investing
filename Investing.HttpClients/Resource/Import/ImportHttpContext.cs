namespace Investing.HttpClients.Resource.Import
{
    public class ImportHttpContext : IImportHttpContext
    {
        public IProductHttpClient Product => new ProductHttpClient();

        public IDividendHttpClient Dividend => new DividendHttpClient();

        public IQuotationHttpClient Quotation => new QuotationHttpClient();
    }
}
