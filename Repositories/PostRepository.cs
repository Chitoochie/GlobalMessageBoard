using GlobalMessageBoard.Data;
using GlobalMessageBoard.Interfaces;
using GlobalMessageBoard.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalMessageBoard.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Post> GetByIdAsync(int id)
        {
            return await context
                .Posts
                .Include(x => x.Posts)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }

}
