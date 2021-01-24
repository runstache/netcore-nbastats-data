using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class BoxScoreEntry
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public long ScheduleId { get; set; }
        public int Quarter1 { get; set; }
        public int Quarter2 { get; set; }
        public int Quarter3 { get; set; }
        public int Quarter4 { get; set; }
        public int Ot { get; set; }
        public int Total { get; set; }

    }
}
