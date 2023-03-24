namespace Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Points { get; set; }
        public IList<Bet> Bets { get; set; } = new List<Bet>();
    }
}