namespace Infrastructure.Data.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; } = "https://via.placeholder.com/150x150.png?text=Company+Logo";
        public virtual ICollection<UserEntity> Members { get; set; }
        public virtual ICollection<PredictionGroupEntity> PredictionGroups { get; set; }
    }
}