using Microsoft.AspNetCore.Identity;

namespace GlobalMessageBoard.Models.Data
{
    public class Post : Base
    {
        public string? Title { get; set; }

        public string? Text { get; set; }

        public Media? Media { get; set; }

        public DateTime Date { get; set;}

        public IdentityUser? User { get; set; }

        public IEnumerable<Post>? Posts { get; set; }

        public int ChainId { get; set; }

        public Chain? Chain { get; set; }
    }
}
