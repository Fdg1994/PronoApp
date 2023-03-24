using Core.Enums;

namespace Core.Domain.Entities
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
}