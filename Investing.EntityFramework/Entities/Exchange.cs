using Investing.Core.Domain;
using Investing.Core.Specification;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class Exchange : EntityFrameworkEntityBase, IAggregateRoot, IUniqueSpecification<Exchange>
    {
        public string Title { get; set; }

        public Expression<Func<Exchange, bool>> Unique => (item) => item.Title == Title;

        public virtual ICollection<Product>? Products { get; set; }

        public override async Task ImportAsync(IImporterVisitor visitor)
        {
            await visitor.ImportAsync(this);
        }
    }
}