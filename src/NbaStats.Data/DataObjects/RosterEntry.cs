using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class RosterEntry
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public long PlayerId { get; set; }
    }
}
