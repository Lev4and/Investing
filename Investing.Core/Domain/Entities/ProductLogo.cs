namespace Investing.Core.Domain.Entities
{
    public class ProductLogo
    {
        public string Url { get; }

        public ProductLogo(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            Url = url;
        }
    }
}
