using Investing.Core.Domain;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class Exchange : EntityBase, IAggregateRoot, IUniqueSpecification<Exchange>
    {
        public string Title { get; set; }

        public Expression<Func<Exchange, bool>> Unique => (item) => item.Title == Title;

        public virtual ICollection<Product>? Products { get; set; }
    }
}