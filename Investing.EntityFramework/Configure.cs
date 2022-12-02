using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Investing.EntityFramework
{
    public static class Configure
    {
        public static void AddEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<InvestingDbContext>((options) =>
            {
                options
                    .UseNpgsql("Server=lev4and.ru;Database=Investing;User Id=postgres;Password=sa;" +
                        "Integrated Security=true;Pooling=true;")
                    .UseSnakeCaseNamingConvention();
            });
        }
    }
}