using Investing.Core.Domain;
using Investing.Core.Specification;

namespace Investing.Core.Repository
{
    public interface IGridRepository
    {
        ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase, IAggregateRoot;

        Task<IEnumerable<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase, 
            IAggregateRoot;
    }
}
