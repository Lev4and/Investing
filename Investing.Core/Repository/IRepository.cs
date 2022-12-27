using Investing.Core.Domain;
using Investing.Core.Specification;

namespace Investing.Core.Repository
{
    public interface IRepository
    {
        Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot, 
            IUniqueSpecification<TEntity>;

        Task<TEntity?> FindUniqueByExpressionAsync<TEntity>(IUniqueSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IUniqueSpecification<TEntity>;

        Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : EntityBase, 
            IAggregateRoot, IUniqueSpecification<TEntity>;

        Task<IEnumerable<TEntity>> FindAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : EntityBase,
            IAggregateRoot, IUniqueSpecification<TEntity>;

        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IUniqueSpecification<TEntity>;

        Task<TEntity> TryImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IUniqueSpecification<TEntity>;

        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IUniqueSpecification<TEntity>;
    }
}
