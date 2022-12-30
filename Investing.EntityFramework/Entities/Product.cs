using Investing.Core.Domain;
using Investing.Core.Specification;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Issuer))]
    [Index(nameof(ClassCode))]
    [Index(nameof(SecurCode))]
    [Index(nameof(Capitalization))]
    public class Product : EntityFrameworkEntityBase, IAggregateRoot, IEqualSpecification<Product>
    {
        public Guid AssetId { get; set; }

        public Guid SectorId { get; set; }

        public Guid CurrencyId { get; set; }

        public Guid ExchangeId { get; set; }

        public Guid? BondTypeId { get; set; }

        public Guid PortfolioId { get; set; }

        public string Issuer { get; set; }

        public string ClassCode { get; set; }

        public string SecurCode { get; set; }

        public decimal? Capitalization { get; set; }

        public virtual Asset? Asset { get; set; }

        public virtual Sector? Sector { get; set; }

        public virtual ProductLogo? Logo { get; set; }

        public virtual BondType? BondType { get; set; }

        public virtual Currency? Currency { get; set; }

        public virtual Exchange? Exchange { get; set; }

        public virtual Portfolio? Portfolio { get; set; }

        public Expression<Func<Product, bool>> IsEqual => (item) => item.Issuer == Issuer &&
            item.SecurCode == SecurCode && item.ClassCode == ClassCode;

        public virtual ICollection<ProductPrice>? Prices { get; set; }

        public override async Task Accept(IImporterVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
