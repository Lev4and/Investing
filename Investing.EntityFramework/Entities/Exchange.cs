using Investing.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(Title))]
    public class Exchange : EntityBase, IAggregateRoot
    {
        public string Title { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}