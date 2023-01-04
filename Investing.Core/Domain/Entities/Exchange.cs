namespace Investing.Core.Domain.Entities
{
    public class Exchange : EntityBase
    {
        public string Title { get; }

        public Exchange(Guid id, string title)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));

            Id = id;
            Title = title;
        }
    }
}
