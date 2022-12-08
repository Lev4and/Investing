using Investing.Core.Domain.Entities;
using Investing.EntityFramework.Core;
using Investing.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework
{
    public class InvestingDbContext : AppDbContextBase
    {
        public DbSet<Asset> Assets { get; set; }

        public DbSet<BondType> BondTypes { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Exchange> Exchanges { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductLogo> ProductLogos { get; set; }

        public DbSet<ProductPrice> ProductPrices { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public InvestingDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Asset>().OneToMany(entity => entity.Products, entity => entity.Asset, 
                entity => entity.AssetId);

            builder.Entity<BondType>().OneToMany(entity => entity.Products, entity => entity.BondType, 
                entity => entity.BondTypeId);

            builder.Entity<Currency>().OneToMany(entity => entity.Products, entity => entity.Currency,
                entity => entity.CurrencyId);

            builder.Entity<Exchange>().OneToMany(entity => entity.Products, entity => entity.Exchange,
                entity => entity.ExchangeId);

            builder.Entity<Portfolio>().OneToMany(entity => entity.Products, entity => entity.Portfolio,
                entity => entity.PortfolioId);

            builder.Entity<Product>().OneToOne(entity => entity.Logo, entity => entity.Product,
                entity => entity.ProductId);

            builder.Entity<Product>().OneToMany(entity => entity.Prices, entity => entity.Product,
                entity => entity.ProductId);

            builder.Entity<Sector>().OneToMany(entity => entity.Products, entity => entity.Sector,
                entity => entity.SectorId);
        }
    }
}