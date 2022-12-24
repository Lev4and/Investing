using Investing.Core.Domain;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class Sector : EntityBase, IAggregateRoot, IUniqueSpecification<Sector>
    {
        public string Title { get; set; }

        public Expression<Func<Sector, bool>> Unique => (item) => item.Title == Title;

        public virtual ICollection<Product>? Products { get; set; }
    }
}