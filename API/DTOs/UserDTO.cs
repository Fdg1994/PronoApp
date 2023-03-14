using Infrastructure.Data.Entities;

namespace API.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public int Points { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }
        public string CompanyRole { get; set; }
        public string Token { get; set; }

    }
}