using Investing.Core.Domain;
using Investing.Core.Repository;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework.Core
{
    public class BaseRepository<TDbContext, TEntity> : IRepository<TEntity>, IGridRepository<TEntity> 
        where TEntity : EntityBase, IAggregateRoot
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        protected BaseRepository(TDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> FindByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<TEntity?> FindOneAsync(ISpecification<TEntity> specification)
        {
            return await GetQuery(_context.Set<TEntity>(), specification).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            return await GetQuery(_context.Set<TEntity>(), specification).ToListAsync();
        }

        public async ValueTask<long> CountAsync(IGridSpecification<TEntity> specification)
        {
            specification.IsPagingEnabled = false;

            return await ValueTask.FromResult(GetQuery(_context.Set<TEntity>(), specification).LongCount());
        }

        public async Task<IEnumerable<TEntity>> FindAsync(IGridSpecification<TEntity> specification)
        {
            return await GetQuery(_context.Set<TEntity>(), specification).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().SingleInsertAsync(entity);

            return entity;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _context.Set<TEntity>().SingleDeleteAsync(entity);
        }

        private static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification)
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

        private static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            IGridSpecification<TEntity> specification)
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
