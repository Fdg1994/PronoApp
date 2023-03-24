using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PictureUrl { get; set; }
        public string Branch { get; set; }
        public int Points { get; set; } = 100;
        public UserRole Role { get; set; } = UserRole.User;
        public int CompanyEntityId { get; set; }
        public CompanyEntity Company { get; set; }
        public CompanyMemberRole CompanyRole { get; set; } = CompanyMemberRole.Member;
        public ICollection<BetEntity> Bets { get; set; }
    }
}