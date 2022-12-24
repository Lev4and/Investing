using Investing.Core.Domain;
using Investing.Core.Specification;

namespace Investing.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        Task<TEntity?> FindByIdAsync(Guid id);

        Task<TEntity?> FindOneAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification);

        Task<TEntity> AddAsync(TEntity entity);

        Task RemoveAsync(TEntity entity);
    }
}
