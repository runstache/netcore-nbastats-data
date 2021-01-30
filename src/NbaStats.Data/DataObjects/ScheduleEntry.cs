using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class ScheduleEntry
    {
        public long Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime GameDate { get; set; }
    }
}
