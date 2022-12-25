using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Investing.EntityFramework
{
    public class InvestingDbContextFactory : IDesignTimeDbContextFactory<InvestingDbContext>
    {
        public InvestingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseNpgsql("", builder => builder.MigrationsAssembly("Investing.EntityFramework"));
            builder.UseSnakeCaseNamingConvention();

            return new InvestingDbContext(builder.Options);
        }
    }
}
