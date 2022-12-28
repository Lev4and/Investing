using Investing.Core.Domain;
using Investing.Core.Specification;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(ProductId))]
    [Index(nameof(Open))]
    [Index(nameof(High))]
    [Index(nameof(Low))]
    [Index(nameof(Volume))]
    [Index(nameof(ClosedAt))]
    public class ProductPrice : EntityFrameworkEntityBase, IAggregateRoot, IEqualSpecification<ProductPrice>
    {
        public Guid ProductId { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public DateTime ClosedAt { get; set; }

        public Expression<Func<ProductPrice, bool>> IsEqual => (item) => item.ProductId == ProductId && 
            item.ClosedAt == ClosedAt;

        public virtual Product? Product { get; set; }

        public override async Task ImportAsync(IImporterVisitor visitor)
        {
            await visitor.ImportAsync(this);
        }
    }
}
