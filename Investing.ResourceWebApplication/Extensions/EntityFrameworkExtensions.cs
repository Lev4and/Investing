using Investing.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Investing.ResourceWebApplication
{
    public static class EntityFrameworkExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<InvestingDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            return builder;
        }
    }
}