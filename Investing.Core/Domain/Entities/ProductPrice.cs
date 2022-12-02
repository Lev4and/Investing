namespace Investing.Core.Domain.Entities
{
    public class ProductPrice : EntityBase, IAggregateRoot
    {
        public Guid ProductId { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public DateTime ClosedAt { get; set; }

        public virtual Product? Product { get; set; }
    }
}
