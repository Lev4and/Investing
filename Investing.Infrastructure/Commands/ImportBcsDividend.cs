using FluentValidation;
using Investing.Core.Abstracts;
using Investing.Core.Domain.Cqrs;
using Investing.Core.Domain.Entities;
using Investing.EntityFramework.Abstracts;
using Investing.HttpClients.Resource.Import.RequestModels;
using Investing.Infrastructure.Builders;
using MediatR;
using DomainEntities = Investing.Core.Domain.Entities;
using EntityFrameworkEntities = Investing.EntityFramework.Entities;
using ResponseModels = Investing.HttpClients.BcsApi.ResponseModels;

namespace Investing.Infrastructure.Commands
{
    public class ImportBcsDividend : ICommand<DomainEntities.Product>
    {
        ImportBcsDividendsModel Model { get; }

        public ImportBcsDividend(ImportBcsDividendsModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            Model = model;
        }

        internal class Validator : AbstractValidator<ImportBcsDividend>
        {
            public Validator()
            {
                RuleFor(model => model.Model.Partner).Null().WithMessage($"The {nameof(Model.Partner)} should " +
                    $"be not null");

                RuleFor(model => model.Model.HistoryDividends).Null().WithMessage($"The {nameof(Model.HistoryDividends)} " +
                    $"should be not null");
            }
        }

        internal class Handler : IRequestHandler<ImportBcsDividend, DomainEntities.Product>
        {
            private readonly IProductBuilder _builder;
            private readonly IImporterVisitor _visitor;
            private readonly IFactory<EntityFrameworkEntities.Product, DomainEntities.Product> _productFactory;
            private readonly IEntityFrameworkFactory<ResponseModels.PartnerBase, EntityFrameworkEntities.Product> _productDbFactory;
            private readonly IEntityFrameworkFactory<ResponseModels.Dividend, EntityFrameworkEntities.ProductDividend> _productDividendDbFactory;

            public Handler(IProductBuilder builder, IImporterVisitor visitor, 
                IFactory<EntityFrameworkEntities.Product, DomainEntities.Product> productFactory, 
                IEntityFrameworkFactory<ResponseModels.PartnerBase, EntityFrameworkEntities.Product> productDbFactory, 
                IEntityFrameworkFactory<ResponseModels.Dividend, EntityFrameworkEntities.ProductDividend> productDividendDbFactory)
            {
                _builder = builder;
                _visitor = visitor;
                _productFactory = productFactory;
                _productDbFactory = productDbFactory;
                _productDividendDbFactory = productDividendDbFactory;
            }

            public async Task<DomainEntities.Product> Handle(ImportBcsDividend request, 
                CancellationToken cancellationToken)
            {
                var product = _builder
                    .WithPartner(request.Model.Partner, _productDbFactory)
                    .WithDividends(request.Model.HistoryDividends, _productDividendDbFactory)
                    .Build();

                await _visitor.Visit(product);

                return _productFactory.Create(product);
            }
        }
    }
}
