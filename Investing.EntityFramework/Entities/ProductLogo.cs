using Investing.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(ProductId))]
    public class ProductLogo : EntityBase, IAggregateRoot
    {
        public Guid ProductId { get; set; }

        public string Value { get; set; }

        public virtual Product? Product { get; set; }
    }
}
