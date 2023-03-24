namespace Core.Domain.Entities
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<GameEntity> Games { get; set; }
    }
}