namespace API.DTOs
{
    public class CompanyDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
        public ICollection<EventDTO> PredictionGroups { get; set; }
    }
}