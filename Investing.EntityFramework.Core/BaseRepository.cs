using Investing.Core.Domain;
using Investing.Core.Repository;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework.Core
{
    public class BaseRepository : IRepository, IGridRepository
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot,
            IUniqueSpecification<TEntity>
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<TEntity?> FindUniqueByExpressionAsync<TEntity>(IUniqueSpecification<TEntity> specification) 
            where TEntity : EntityBase, IAggregateRoot, IUniqueSpecification<TEntity>
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(specification.Unique);
        }

        public async Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity :
            EntityBase, IAggregateRoot, IUniqueSpecification<TEntity>
        {
            return await GetQuery(_context.Set<TEntity>(), specification).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IUniqueSpecification<TEntity>
        {
            return await GetQuery(_context.Set<TEntity>(), specification).ToListAsync();
        }

        public async ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot
        {
            specification.IsPagingEnabled = false;

            return await ValueTask.FromResult(GetQuery(_context.Set<TEntity>(), specification).LongCount());
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot
        {
            return await GetQuery(_context.Set<TEntity>(), specification).ToListAsync();
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IUniqueSpecification<TEntity>
        {
            await _context.Set<TEntity>().SingleInsertAsync(entity);

            return entity;
        }

        public async Task<TEntity> TryImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IUniqueSpecification<TEntity>
        {
            return (await FindUniqueByExpressionAsync(entity)) ?? await AddAsync(entity);
        }

        public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IUniqueSpecification<TEntity>
        {
            await _context.Set<TEntity>().SingleDeleteAsync(entity);
        }

        private static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification) where TEntity : EntityBase, IAggregateRoot
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes
                .Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings
                .Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null) 
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null) 
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.GroupBy != null) 
                query = query.GroupBy(specification.GroupBy)
                    .SelectMany(item => item);

            if (specification.IsPagingEnabled) 
                query = query.Skip(specification.Skip - 1)
                    .Take(specification.Take);

            return query;
        }

        private static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
            IGridSpecification<TEntity> specification) where TEntity : EntityBase, IAggregateRoot
        {
            var query = inputQuery;

            query = specification.Includes
                .Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings
                .Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null) 
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null) 
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.GroupBy != null) 
                query = query.GroupBy(specification.GroupBy)
                    .SelectMany(item => item);

            if (specification.IsPagingEnabled) 
                query = query.Skip(specification.Skip - 1)
                    .Take(specification.Take);

            return query;
        }
    }
}
