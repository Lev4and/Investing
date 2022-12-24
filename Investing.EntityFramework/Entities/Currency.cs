using Investing.Core.Domain;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class Currency : EntityBase, IAggregateRoot, IUniqueSpecification<Currency>
    {
        public string Title { get; set; }

        public Expression<Func<Currency, bool>> Unique => (item) => item.Title == Title;

        public virtual ICollection<Product>? Products { get; set; }
    }
}