using Investing.Core.Domain;
using Investing.Core.Specification;

namespace Investing.Core.Repository
{
    public interface IGridRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        ValueTask<long> CountAsync(IGridSpecification<TEntity> spec);

        Task<IEnumerable<TEntity>> FindAsync(IGridSpecification<TEntity> spec);
    }
}
