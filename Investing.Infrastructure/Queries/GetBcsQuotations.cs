using FluentValidation;
using Investing.Core.Domain.Cqrs;
using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Facades;
using MediatR;

namespace Investing.Infrastructure.Queries
{
    public class GetBcsQuotations : IQuery<HistoryQuotations?>
    {
        public GetHistoryQuotationsModel Model { get; }

        public GetBcsQuotations(GetHistoryQuotationsModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            Model = model;
        }

        internal class Validator : AbstractValidator<GetBcsQuotations>
        {
            public Validator() 
            {
                RuleFor(model => model.Model.SecurCode).Empty().WithMessage($"The {nameof(Model.SecurCode)} should be " +
                    $"not null or empty.");

                RuleFor(model => model.Model.ClassCode).Empty().WithMessage($"The {nameof(Model.ClassCode)} should be " +
                    $"not null or empty.");

                RuleFor(model => model.Model.FromUnix).GreaterThan(model => model.Model.ToUnix)
                    .WithMessage($"The {nameof(Model.FromUnix)} should be less than {nameof(Model.ToUnix)}");

                RuleFor(model => model.Model.ToUnix).LessThan(model => model.Model.FromUnix)
                    .WithMessage($"The {nameof(Model.ToUnix)} should be greater than {nameof(Model.FromUnix)}");
            }
        }

        internal class Handler : IRequestHandler<GetBcsQuotations, ResultModel<HistoryQuotations?>>
        {
            private readonly IBcsFacade _bcs;

            public Handler(IBcsFacade bcs)
            {
                _bcs = bcs;
            }

            public async Task<ResultModel<HistoryQuotations?>> Handle(GetBcsQuotations request, 
                CancellationToken cancellationToken)
            {
                var response = await _bcs.GetHistoryQuotationsAsync(request.Model);

                return new ResultModel<HistoryQuotations?>(response);
            }
        }
    }
}
