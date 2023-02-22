using Infrastructure.Data.Entities;

namespace API.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<string> Members { get; set; }
    }
}