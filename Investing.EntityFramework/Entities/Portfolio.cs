using Investing.Core.Domain;
using Investing.Core.Specification;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class Portfolio : EntityFrameworkEntityBase, IAggregateRoot, IEqualSpecification<Portfolio>
    {
        public string Title { get; set; }

        public Expression<Func<Portfolio, bool>> IsEqual => (item) => item.Title == Title;

        public virtual ICollection<Product>? Products { get; set; }

        public override async Task Accept(IImporterVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}