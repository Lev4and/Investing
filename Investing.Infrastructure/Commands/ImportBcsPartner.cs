using FluentValidation;
using Investing.Core.Domain.Cqrs;
using Investing.EntityFramework.Abstracts;
using Investing.Infrastructure.Factories;
using Investing.HttpClients.BcsApi.ResponseModels;
using MediatR;

namespace Investing.Infrastructure.Commands
{
    public class ImportBcsPartner : ICommand<Guid>
    {
        public Partner Partner { get; }

        public ImportBcsPartner(Partner partner)
        {
            if (partner == null) throw new ArgumentNullException(nameof(partner));

            Partner = partner;
        }

        internal class Validator : AbstractValidator<ImportBcsPartner>
        {
            public Validator() 
            {
                
            }
        }

        internal class Handler : IRequestHandler<ImportBcsPartner, ResultModel<Guid>>
        {
            private readonly IImporterVisitor _importer;

            public Handler(IImporterVisitor importer)
            {
                _importer = importer;
            }

            public async Task<ResultModel<Guid>> Handle(ImportBcsPartner request, CancellationToken cancellationToken)
            {
                var product = new ProductFactory().Create(request.Partner);

                await product.ImportAsync(_importer);

                return new ResultModel<Guid>(product.Id);
            }
        }
    }
}
