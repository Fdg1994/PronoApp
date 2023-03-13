namespace API.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<GameDTO> Games { get; set; }
    }
}