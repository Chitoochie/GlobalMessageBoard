using GlobalMessageBoard.Data;
using GlobalMessageBoard.Interfaces;
using GlobalMessageBoard.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalMessageBoard.Repositories
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Board> GetByIdAsync(int id)
        {
            return await context
                .Boards
                .Include(x => x.Chains)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }

}
