namespace Infrastructure.Data.Entities
{
    public class CompanyUserEntity : BaseEntity
    {
        public int CompanyEntityId { get; set; }
        public CompanyEntity Company { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity User { get; set; }
        public CompanyUserRole Role { get; set; }
    }

    public enum CompanyUserRole
    {
        Member,
        Manager
    }
}