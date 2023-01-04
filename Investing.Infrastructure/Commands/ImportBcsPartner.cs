using FluentValidation;
using Investing.Core.Abstracts;
using Investing.Core.Domain.Cqrs;
using Investing.EntityFramework.Abstracts;
using Investing.HttpClients.BcsApi.ResponseModels;
using MediatR;
using DomainEntities = Investing.Core.Domain.Entities;
using EntityFrameworkEntities = Investing.EntityFramework.Entities;

namespace Investing.Infrastructure.Commands
{
    public class ImportBcsPartner : ICommand<DomainEntities.Product>
    {
        public PartnerBase Partner { get; }

        public ImportBcsPartner(PartnerBase partner)
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

        internal class Handler : IRequestHandler<ImportBcsPartner, DomainEntities.Product>
        {
            private readonly IImporterVisitor _visitor;
            private readonly IFactory<EntityFrameworkEntities.Product, DomainEntities.Product> _productFactory;
            private readonly IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product> _productDbFactory;

            public Handler(IImporterVisitor visitor, 
                IFactory<EntityFrameworkEntities.Product, DomainEntities.Product> productFactory,
                IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product> productDbFactory)
            {
                _visitor = visitor;
                _productFactory = productFactory;
                _productDbFactory = productDbFactory;
            }

            public async Task<DomainEntities.Product> Handle(ImportBcsPartner request, 
                CancellationToken cancellationToken)
            {
                var product = _productDbFactory.Create(request.Partner);

                await product.Accept(_visitor);

                return _productFactory.Create(product);
            }
        }
    }
}
