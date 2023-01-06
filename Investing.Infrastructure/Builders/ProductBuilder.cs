using Investing.EntityFramework.Abstracts;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.EntityFramework.Entities;

namespace Investing.Infrastructure.Builders
{
    public class ProductBuilder : IProductBuilder
    {
        private Product _product;

        public ProductBuilder()
        {
            _product = new Product();
        }

        public IProductBuilder WithPartner(PartnerBase partner,
            IEntityFrameworkFactory<PartnerBase, Product> factory)
        {
            if (partner == null) throw new ArgumentNullException(nameof(partner));
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            _product = factory.Create(partner);

            return this;
        }

        public IProductBuilder WithDividends(HistoryDividends dividends, 
            IEntityFrameworkFactory<Dividend, ProductDividend> factory)
        {
            if (dividends == null) throw new ArgumentNullException(nameof(dividends));
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            _product.Dividends = dividends.Dividends.Select(factory.Create).ToList();

            return this;
        }

        public IProductBuilder WithQuotations(HistoryQuotations quotations,
            IEntityFrameworkFactory<Quotation, ProductPrice> factory)
        {
            if (quotations == null) throw new ArgumentNullException(nameof(quotations));
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            _product.Prices = quotations.Select(factory.Create).ToList();

            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }
}
