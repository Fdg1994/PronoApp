using Azure;

namespace Infrastructure.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PictureUrl { get; set; }
        public string CompanyBranch { get; set; }
        public int Points { get; set; }
        public UserRole Role { get; set; }
        public ICollection<CompanyEntity> Companies { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User
    }
}