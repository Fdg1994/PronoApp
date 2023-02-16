namespace Infrastructure.Data.Entities
{
    public class PredictionGroupEntity : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyEntityId { get; set; }
        public CompanyEntity Company { get; set; }
        public int EventEntityId { get; set; }
        public EventEntity Event { get; set; }
        public int PredictionGroupPoints { get; set; }
    }
}