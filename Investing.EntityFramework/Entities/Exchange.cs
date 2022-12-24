using Investing.Core.Domain;

namespace Investing.EntityFramework.Entities
{
    public class Exchange : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}