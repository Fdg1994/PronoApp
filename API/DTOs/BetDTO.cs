namespace API.DTOs
{
    public class BetDTO
    {
        public DateTime OpenBetTime { get; set; }
        public DateTime CloseBetTime { get; set; }
        public string Status { get; set; }
        public int BetAmount { get; set; }
        public string PredictedOutcome { get; set; }
        public int UserEntityId { get; set; }
        public UserDTO User { get; set; }
        public int GameEntityId { get; set; }
        public GameDTO Game { get; set; }
    }
}