namespace API.DTOs
{
    public class GameDTO
    {
        public string Name     
        {
            get { return Team1 + " - " + Team2; }
            set {;}
        }
        public string Status { get; set; }
        public DateTime StartTimeGame { get; set; }
        public DateTime EndTimeGame { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public int EventEntityId { get; set; }
        public EventDTO Event { get; set; }
    }
}