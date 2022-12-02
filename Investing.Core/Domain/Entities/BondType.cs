namespace Investing.Core.Domain.Entities
{
    public class BondType : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
