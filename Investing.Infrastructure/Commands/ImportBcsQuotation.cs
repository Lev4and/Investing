using FluentValidation;
using Investing.Core.Abstracts;
using Investing.Core.Domain.Cqrs;
using Investing.EntityFramework.Abstracts;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.HttpClients.Resource.Import.RequestModels;
using Investing.Infrastructure.Builders;
using MediatR;
using DomainEntities = Investing.Core.Domain.Entities;
using EntityFrameworkEntities = Investing.EntityFramework.Entities;

namespace Investing.Infrastructure.Commands
{
    public class ImportBcsQuotation : ICommand<DomainEntities.Product>
    {
        public ImportBcsQuotationModel Model { get; }

        public ImportBcsQuotation(ImportBcsQuotationModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            Model = model;
        }

        internal class Validator : AbstractValidator<ImportBcsQuotation>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportBcsQuotation, DomainEntities.Product>
        {
            private readonly IProductBuilder _builder;
            private readonly IImporterVisitor _visitor;
            private readonly IFactory<EntityFrameworkEntities.Product, DomainEntities.Product> _productFactory;
            private readonly IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product> _productDbFactory;
            private readonly IEntityFrameworkFactory<Quotation, EntityFrameworkEntities.ProductPrice> _productPriceDbFactory;

            public Handler(IProductBuilder builder, IImporterVisitor visitor,
                IFactory<EntityFrameworkEntities.Product, DomainEntities.Product> productFactory,
                IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product> productDbFactory,
                IEntityFrameworkFactory<Quotation, EntityFrameworkEntities.ProductPrice> productPriceDbFactory)
            {
                _builder = builder;
                _visitor = visitor;
                _productFactory = productFactory;
                _productDbFactory = productDbFactory;
                _productPriceDbFactory = productPriceDbFactory;
            }

            public async Task<DomainEntities.Product> Handle(ImportBcsQuotation request, 
                CancellationToken cancellationToken)
            {
                var product = _builder
                    .WithPartner(request.Model.Partner, _productDbFactory)
                    .WithQuotations(request.Model.HistoryQuotations, _productPriceDbFactory)
                    .Build();

                await _visitor.Visit(product);

                return _productFactory.Create(product);
            }
        }
    }
}
