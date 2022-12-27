using FluentValidation;
using Investing.EntityFramework;
using Investing.HttpClients;
using Investing.Infrastructure.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Investing.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClients();
            services.AddEntityFramework();

            services.AddMediatR(typeof(Configure).Assembly);
            services.AddValidatorsFromAssembly(typeof(Configure).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
