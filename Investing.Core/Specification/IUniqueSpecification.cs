using System.Linq.Expressions;

namespace Investing.Core.Specification
{
    public interface IUniqueSpecification<TEntity> : IRootSpecification
    {
        Expression<Func<TEntity, bool>> Unique { get; }
    }
}
