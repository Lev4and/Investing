using Investing.EntityFramework.Core;

namespace Investing.EntityFramework
{
    public class InvestingRepository : BaseRepository
    {
        public InvestingRepository(InvestingDbContext context) : base(context) 
        {

        }
    }
}
