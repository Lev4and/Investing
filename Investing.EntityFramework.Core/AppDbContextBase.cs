using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Investing.EntityFramework.Core
{
    public abstract class AppDbContextBase : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public AppDbContextBase(DbContextOptions options) : base(options)
        {

        }
    }
}
