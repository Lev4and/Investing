using System.Linq.Expressions;

namespace Investing.Core.Specification
{
    public interface IGridSpecification<T> : IRootSpecification
    {
        bool IsPagingEnabled { get; set; }

        int Take { get; }

        int Skip { get; }

        Expression<Func<T, object>> GroupBy { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }

        List<string> IncludeStrings { get; }

        List<Expression<Func<T, bool>>> Criterias { get; }

        List<Expression<Func<T, object>>> Includes { get; }
    }
}
