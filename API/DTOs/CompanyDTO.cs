using Infrastructure.Data.Entities;

namespace API.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<string> Members { get; set; }
    }
}