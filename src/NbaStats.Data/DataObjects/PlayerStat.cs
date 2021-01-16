using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class PlayerStat
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public int GameMinutes { get; set; }
        public int FGTaken { get; set; }
        public int FGCompleted { get; set; }
        public double FGPercentage { get; set; }
        public int ThreeTaken { get; set; }
        public int ThreeCompleted { get; set; }
        public double ThreePercentage { get; set; }
        public int OffensiveRebound { get; set; }
        public int DefensiveRebound { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Turnovers { get; set; }
        public int Fouls { get; set; }
        public int Points { get; set; }
        public int PointDifferential { get; set; }
    }
}
