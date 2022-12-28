using Investing.Core.Domain;
using Investing.Core.Specification;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class BondType : EntityFrameworkEntityBase, IAggregateRoot, IEqualSpecification<BondType>
    {
        public string Title { get; set; }

        public Expression<Func<BondType, bool>> IsEqual => (item) => item.Title == Title;

        public virtual ICollection<Product>? Products { get; set; }

        public override async Task ImportAsync(IImporterVisitor visitor)
        {
            await visitor.ImportAsync(this);
        }
    }
}
