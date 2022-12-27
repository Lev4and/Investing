using MediatR;

namespace Investing.Core.Domain.Cqrs
{
    public interface IQuery<T> : IRequest<ResultModel<T>>
    {

    }
}
