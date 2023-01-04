namespace Investing.Core.Domain.Entities
{
    public class Asset : EntityBase
    {
        public string Title { get; }

        public Asset(Guid id, string title) 
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id)); 
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));

            Id = id;
            Title = title;
        }
    }
}
