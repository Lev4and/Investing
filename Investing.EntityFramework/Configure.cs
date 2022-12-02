using Microsoft.Extensions.DependencyInjection;

namespace Investing.EntityFramework
{
    public static class Configure
    {
        public static void AddEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<InvestingDbContext>();
        }
    }
}