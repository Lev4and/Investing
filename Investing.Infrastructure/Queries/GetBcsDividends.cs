using FluentValidation;
using Investing.Core.Domain.Cqrs;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Facades;
using MediatR;

namespace Investing.Infrastructure.Queries
{
    public class GetBcsDividends : IQuery<HistoryDividends?>
    {
        public string SecurCode { get; }
        
        public GetBcsDividends(string securCode) 
        {
            if (string.IsNullOrEmpty(securCode)) throw new ArgumentNullException(nameof(securCode));

            SecurCode = securCode;
        }

        internal class Validator : AbstractValidator<GetBcsDividends>
        {
            public Validator()
            {
                RuleFor(model => model.SecurCode).Null().WithMessage($"The {nameof(SecurCode)} should be not null.");
                RuleFor(model => model.SecurCode).Empty().WithMessage($"The {nameof(SecurCode)} should be not empty.");
            }
        }

        internal class Handler : IRequestHandler<GetBcsDividends, HistoryDividends?>
        {
            private readonly IBcsFacade _bcs;

            public Handler(IBcsFacade bcs)
            {
                _bcs = bcs;
            }

            public async Task<HistoryDividends?> Handle(GetBcsDividends request, CancellationToken cancellationToken)
            {
                return await _bcs.GetHistoryDividendsAsync(request.SecurCode);
            }
        }
    }
}
