using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class TeamStat
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public int OpponentId { get; set; }
        public int FGTaken { get; set; }
        public int FGCompleted { get; set; }
        public double FGPercentage { get; set; }
        public int ThreeTaken { get; set; }
        public int ThreeCompleted { get; set; }
        public double ThreePercentage { get; set; }
        public int FreeThrowsTaken { get; set; }
        public int FreeThrowsCompleted { get; set; }
        public double FreeThrowPercentage { get; set; }
        public int OffensiveRebound { get; set; }
        public int DefensiveRebound { get; set; }
        public int Assits { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int TurnOvers { get; set; }
        public int Fouls { get; set; }
    }
}
