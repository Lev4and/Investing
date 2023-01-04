using System.Linq.Expressions;

namespace Investing.Core.Specification
{
    public interface IEqualSpecification<TEntity> : IRootSpecification
    {
        Expression<Func<TEntity, bool>> IsEqual { get; }
    }
}
