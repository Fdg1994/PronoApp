namespace Infrastructure.Data.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<UserEntity> Users { get; set; }
        public ICollection<PredictionGroupEntity> PredictionGroups { get; set; }
    }
}