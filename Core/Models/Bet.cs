using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Bet
    {
        public DateTime OpenBetTime { get; set; }
        public DateTime CloseBetTime { get; set; }
        public BetStatus Status { get; set; } = BetStatus.Placed;
        public int BetAmount { get; set; }
        public PredictedOutcome PredictedOutcome { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
    }
}
