using Investing.Core.Domain;
using Investing.Core.Specification;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    [Index(nameof(Yield))]
    [Index(nameof(ClosePrice))]
    [Index(nameof(DividendValue))]
    [Index(nameof(LastBuyDay))]
    [Index(nameof(ClosingDate))]
    public class ProductDividend : EntityFrameworkEntityBase, IAggregateRoot, IEqualSpecification<ProductDividend>
    {
        public Guid ProductId { get; set; }

        public string Title { get; set; }

        public decimal? Yield { get; set; }

        public decimal ClosePrice { get; set; }

        public decimal DividendValue { get; set; }

        public DateTime LastBuyDay { get; set; }

        public DateTime ClosingDate { get; set; }

        public virtual Product? Product { get; set; }

        public Expression<Func<ProductDividend, bool>> IsEqual => (item) => item.Title == Title;

        public override async Task Accept(IImporterVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
