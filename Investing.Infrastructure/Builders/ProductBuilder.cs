using Investing.EntityFramework.Abstracts;
using Investing.HttpClients.BcsApi.ResponseModels;
using EntityFrameworkEntities = Investing.EntityFramework.Entities;

namespace Investing.Infrastructure.Builders
{
    public class ProductBuilder
    {
        private readonly IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product> _productFactory;
        private readonly IEntityFrameworkFactory<Quotation, EntityFrameworkEntities.ProductPrice> _productPriceFactory;

        private EntityFrameworkEntities.Product _product;

        public ProductBuilder(PartnerBase partner, 
            IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product> productFactory, 
            IEntityFrameworkFactory<Quotation, EntityFrameworkEntities.ProductPrice> productPriceFactory)
        {
            _productFactory = productFactory;
            _productPriceFactory = productPriceFactory;

            _product = _productFactory.Create(partner);
        }

        public ProductBuilder WithQuotations(HistoryQuotations quotations)
        {
            _product.Prices = quotations.Select(_productPriceFactory.Create).ToList();

            return this;
        }

        public EntityFrameworkEntities.Product Buid()
        {
            return _product;
        }
    }
}
