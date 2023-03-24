using Core.Enums;

namespace Core.Domain.Entities
{
    public class GameEntity : BaseEntity
    {
        public GameStatus Status { get; set; } = GameStatus.Upcoming;
        public DateTime StartTimeGame { get; set; }
        public DateTime EndTimeGame { get; set; }
        public TeamEntity Team1 { get; set; }
        public TeamEntity Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public int EventEntityId { get; set; }
        public EventEntity Event { get; set; }
        public ICollection<BetEntity> Bets { get; set; }
    }
}