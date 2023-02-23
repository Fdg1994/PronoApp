using Infrastructure.Data.Entities;

namespace API.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Company { get; set; }
        public string CompanyRole { get; set; }
        public int Points { get; set; }
        public string Token { get; set; }
    }
}