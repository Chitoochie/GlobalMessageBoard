using GlobalMessageBoard.Data;
using GlobalMessageBoard.Interfaces;
using GlobalMessageBoard.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalMessageBoard.Repositories
{
    public class ChainRepository : Repository<Chain>, IChainRepository
    {
        public ChainRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Chain> GetByIdAsync(int id)
        {
            return await context
                .Chains
                .Include(x => x.Posts)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }

}
