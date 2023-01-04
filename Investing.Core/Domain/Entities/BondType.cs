namespace Investing.Core.Domain.Entities
{
    public class BondType : EntityBase
    {
        public string Title { get; }

        public BondType(Guid id, string title) 
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));

            Id = id;
            Title = title;
        }
    }
}
