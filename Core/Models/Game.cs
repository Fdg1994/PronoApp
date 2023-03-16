using Core.Enums;

namespace Core.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name
        {
            get { return $"{Team1.Name} VS {Team2.Name}"; }
        }
        public GameStatus Status { get; set; } = GameStatus.Upcoming;
        public DateTime StartTimeGame { get; set; }
        public DateTime EndTimeGame { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public SportEvent Event { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
