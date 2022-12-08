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
                    .UseNpgsql($"Host={Environment.GetEnvironmentVariable("ASPNETCORE_POSTGRES_DB_SERVER")};" +
                        $"Port={Environment.GetEnvironmentVariable("ASPNETCORE_POSTGRES_DB_SERVER_PORT")};" +
                        $"Database={Environment.GetEnvironmentVariable("ASPNETCORE_POSTGRES_DB_NAME")};" +
                        $"Username={Environment.GetEnvironmentVariable("ASPNETCORE_POSTGRES_DB_USER")};" +
                        $"Password={Environment.GetEnvironmentVariable("ASPNETCORE_POSTGRES_DB_PASSWORD")};" +
                        "Integrated Security=true;Pooling=true;")
                    .UseSnakeCaseNamingConvention();
            });
        }
    }
}