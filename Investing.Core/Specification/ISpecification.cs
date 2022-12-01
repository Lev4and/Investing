using System.Linq.Expressions;

namespace Investing.Core.Specification
{
    public interface ISpecification<T> : IRootSpecification
    {
        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }

        Expression<Func<T, bool>> Criteria { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        Expression<Func<T, object>> GroupBy { get; }

        List<string> IncludeStrings { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        bool IsSatisfiedBy(T obj);
    }
}
