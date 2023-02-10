using Azure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PictureUrl { get; set; }
        public string CompanyBranch { get; set; }
        public int Points { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public ICollection<CompanyEntity> Companies { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User
    }
}