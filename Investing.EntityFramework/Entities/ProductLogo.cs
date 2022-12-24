using Investing.Core.Domain;

namespace Investing.EntityFramework.Entities
{
    public class ProductLogo : EntityBase, IAggregateRoot
    {
        public Guid ProductId { get; set; }

        public string Value { get; set; }

        public virtual Product? Product { get; set; }
    }
}
