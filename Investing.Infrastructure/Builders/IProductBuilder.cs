using Investing.Core.Abstracts;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;
using Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.Infrastructure.Builders
{
    public interface IProductBuilder : IBuilder<Product>
    {
        IProductBuilder WithPartner(PartnerBase partner,
            IEntityFrameworkFactory<PartnerBase, Product> factory);

        IProductBuilder WithDividends(HistoryDividends dividends,
            IEntityFrameworkFactory<Dividend, ProductDividend> factory);

        IProductBuilder WithQuotations(HistoryQuotations quotations,
            IEntityFrameworkFactory<Quotation, ProductPrice> factory);
    }
}
