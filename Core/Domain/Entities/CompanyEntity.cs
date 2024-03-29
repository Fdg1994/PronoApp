namespace Core.Domain.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; } = "https://via.placeholder.com/150x150.png?text=Company+Logo";
        public ICollection<UserEntity> Members { get; set; }
        public ICollection<EventEntity> PredictionGroups { get; set; }
    }
}