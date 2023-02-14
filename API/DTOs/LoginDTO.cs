namespace API.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public string Role { get; set; }
    }
}