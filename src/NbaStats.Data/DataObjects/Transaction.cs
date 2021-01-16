using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class Transaction
    {
        public long Id { get; set; }
        public int PlayerId { get; set; }
        public int OldTeamId { get; set; }
        public int NewTeamId { get; set; }
    }
}
