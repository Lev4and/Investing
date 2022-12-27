using FluentValidation;
using Investing.Core.Domain.Cqrs;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Facades;
using MediatR;

namespace Investing.Infrastructure.Queries
{
    public class GetBcsPartners : IQuery<PartnerQuotations?>
    {
        public int Offset { get; }

        public GetBcsPartners(int offset = 0)
        {
            Offset= offset;
        }

        internal class Validator : AbstractValidator<GetBcsPartners>
        {
            public Validator()
            {
                RuleFor(model => model.Offset).LessThan(0).WithMessage($"{nameof(Offset)} should at greater than " +
                    $"or equal to 0.");
            }
        }

        internal class Handler : IRequestHandler<GetBcsPartners, ResultModel<PartnerQuotations?>>
        {
            private readonly IBcsFacade _bcs;

            public Handler(IBcsFacade bcs)
            {
                _bcs = bcs;
            }

            public async Task<ResultModel<PartnerQuotations?>> Handle(GetBcsPartners request, 
                CancellationToken cancellationToken)
            {
                var response = await _bcs.GetPartnerQuotationsAsync(request.Offset);

                return new ResultModel<PartnerQuotations?>(response);
            }
        }
    }
}
