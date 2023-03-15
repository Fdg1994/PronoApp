namespace Infrastructure.Data.Entities
{
    public class BetEntity : BaseEntity
    {
        public DateTime OpenBetTime { get; set; }
        public DateTime CloseBetTime { get; set; }
        public BetStatus Status { get; set; } = BetStatus.Placed;
        public int BetAmount { get; set; }
        public PredictedOutcome PredictedOutcome { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity User { get; set; }
        public int GameEntityId { get; set; }
        public GameEntity Game { get; set; }
    }

    public enum BetStatus
    {
        Placed,
        Won,
        Lost,
        Refunded
    }

    public enum PredictedOutcome
    {
        Team1,
        Team2,
        Draw
    }
}