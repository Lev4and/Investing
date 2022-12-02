using Investing.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework
{
    public class InvestingDbContext : AppDbContextBase
    {
        public InvestingDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("Server=lev4and.ru;Database=Investing;User Id=postgres;Password=sa;" +
                        "Integrated Security=true;Pooling=true;", builder => 
                            builder.MigrationsAssembly("Investing.ResourceWebApplication"))
                    .UseSnakeCaseNamingConvention();
            }
        }
    }
}