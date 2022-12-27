using MediatR;

namespace Investing.Core.Domain.Cqrs
{
    public interface ICommand<T> : IRequest<ResultModel<T>>
    {

    }
}
