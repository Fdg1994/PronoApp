namespace Infrastructure.Data.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public virtual ICollection<UserEntity> Members { get; set; }
        public virtual ICollection<PredictionGroupEntity> PredictionGroups { get; set; }
    }
}