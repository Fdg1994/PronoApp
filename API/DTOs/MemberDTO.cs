namespace API.DTOs
{
    public class MemberDTO
    {      
        public string Username { get; set; }
        public string Email { get; set; }
        public string PictureUrl { get; set; }
        public string Branch { get; set; }
        public int Points { get; set; }
        public string Role { get; set; }
        public int CompanyEntityId { get; set; }
        public CompanyDTO Company { get; set; }
        public string CompanyRole { get; set; }
    }
}