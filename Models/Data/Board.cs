namespace GlobalMessageBoard.Models.Data
{
    public class Board : Base 
    {
        public string? Name { get; set; }

        public IEnumerable<Chain>? Chains { get; set; }
    }
}
