﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    public class BetEntity : BaseEntity
    {
        public DateTime OpenBetTime { get; set; }
        public DateTime CloseBetTime { get; set; }
        public BetStatus Status { get; set; }
        public int BetAmount { get; set; }
        public string TeamOutcome { get; set; }
        public  int UserEntityId { get; set; }
        public UserEntity User { get; set; }
        public int GameEntityId { get; set; }
        public GameEntity Game { get; set; }
    }

    public enum BetStatus
    {
        Placed,
        Won,
        Lost,
        Refunded
    }
}
