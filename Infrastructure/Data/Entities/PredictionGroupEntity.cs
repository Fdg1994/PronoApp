namespace Infrastructure.Data.Entities
{
    public class PredictionGroupEntity : BaseEntity
    {
        public string Name { get; set; }
        public int CompanyEntityId { get; set; }
        public CompanyEntity PredictionGroupCompany { get; set; }
        public int EventEntityId { get; set; }
        public EventEntity PredictionGroupEvent { get; set; }
        public int PredictionGroupPoints { get; set; }
    }
}