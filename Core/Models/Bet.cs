using Core.Enums;

namespace Core.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public DateTime OpenBetTime { get; set; }
        public DateTime CloseBetTime { get; set; }
        public BetStatus Status { get; set; } = BetStatus.Placed;
        public int BetAmount { get; set; }
        public PredictedOutcome PredictedOutcome { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
    }
}