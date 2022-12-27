using FluentValidation;
using Investing.Core.Domain.Cqrs;
using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Entities;
using Investing.EntityFramework.Infrastructure.Factories;
using Investing.HttpClients.BcsApi.ResponseModels;
using MediatR;

namespace Investing.Infrastructure.Commands
{
    public class ImportBcsQuotation : ICommand<Guid>
    {
        public Partner Partner { get; }

        public HistoryQuotations HistoryQuotations { get; }

        public ImportBcsQuotation(Partner partner, HistoryQuotations historyQuotations)
        {
            if (partner == null) throw new ArgumentNullException(nameof(partner));
            if (historyQuotations == null) throw new ArgumentNullException(nameof(historyQuotations));

            Partner = partner;
            HistoryQuotations = historyQuotations;
        }

        internal class Validator : AbstractValidator<ImportBcsQuotation>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportBcsQuotation, ResultModel<Guid>>
        {
            private readonly IImporterVisitor _importer;

            public Handler(IImporterVisitor importer)
            {
                _importer = importer;
            }

            public async Task<ResultModel<Guid>> Handle(ImportBcsQuotation request, CancellationToken cancellationToken)
            {
                var product = new ProductFactory().Create(request.Partner);

                await _importer.ImportAsync(product);

                var factory = new ProductPriceFactory(product.Id);

                foreach(var quotation in request.HistoryQuotations)
                {
                    await _importer.ImportAsync(factory.Create(quotation));
                }

                return new ResultModel<Guid>(product.Id);
            }
        }
    }
}
