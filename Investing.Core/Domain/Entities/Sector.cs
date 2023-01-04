namespace Investing.Core.Domain.Entities
{
    public class Sector : EntityBase
    {
        public string Title { get; }

        public Sector(Guid id, string title)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));

            Id = id;
            Title = title;
        }
    }
}
