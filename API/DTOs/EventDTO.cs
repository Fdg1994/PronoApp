namespace API.DTOs
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTime StartTimeEvent { get; set; }
        public DateTime EndTimeEvent { get; set; }
        public ICollection<string> Games { get; set; }
    }
}