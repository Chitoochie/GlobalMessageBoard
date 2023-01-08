using GlobalMessageBoard.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlobalMessageBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        
        public DbSet<Chain> Chains { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Media> Media { get; set; }
    }
}