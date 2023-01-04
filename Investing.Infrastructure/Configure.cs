using FluentValidation;
using Investing.Core.Abstracts;
using Investing.EntityFramework;
using Investing.EntityFramework.Abstracts;
using Investing.HttpClients;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.Infrastructure.Factories;
using Investing.Infrastructure.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using DomainEntities = Investing.Core.Domain.Entities;
using EntityFrameworkEntities = Investing.EntityFramework.Entities;

namespace Investing.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClients();
            services.AddEntityFramework();

            services.AddSingleton(typeof(IEntityFrameworkFactory<PartnerBase, EntityFrameworkEntities.Product>), 
                typeof(ProductBaseFactory));
            services.AddSingleton(typeof(IEntityFrameworkFactory<Quotation, EntityFrameworkEntities.ProductPrice>),
                typeof(ProductPriceFactory));

            services.AddSingleton(typeof(IFactory<EntityFrameworkEntities.Product, DomainEntities.Product>),
                typeof(ProductFactory));

            services.AddMediatR(typeof(Configure).Assembly);
            services.AddValidatorsFromAssembly(typeof(Configure).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
