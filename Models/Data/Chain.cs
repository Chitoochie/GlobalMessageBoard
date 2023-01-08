using Microsoft.AspNetCore.Identity;

namespace GlobalMessageBoard.Models.Data
{
    public class Chain : Base
    {
        public IEnumerable<Post>? Posts { get; set;}

        public string? Name { get; set;}

        public DateTime Date { get; set;}

        public IdentityUser? User { get; set;}

        public int BoardId { get; set;}

        public Board? Board { get; set;} 
    }
}
