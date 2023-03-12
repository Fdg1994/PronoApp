namespace Infrastructure.Data.Entities
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        public string logoUrl { get; set; }
        public DateTime StartTimeEvent { get; set; }
        public DateTime EndTimeEvent { get; set; }
        public ICollection<GameEntity> Games { get; set; }
    }
}