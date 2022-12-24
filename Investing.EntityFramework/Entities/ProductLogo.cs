using Investing.Core.Domain;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(ProductId))]
    public class ProductLogo : EntityBase, IAggregateRoot, IUniqueSpecification<ProductLogo>
    {
        public Guid ProductId { get; set; }

        public string Value { get; set; }

        public Expression<Func<ProductLogo, bool>> Unique => (item) => item.ProductId == ProductId;

        public virtual Product? Product { get; set; }
    }
}
