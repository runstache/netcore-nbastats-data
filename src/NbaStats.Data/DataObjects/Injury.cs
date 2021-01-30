using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStats.Data.DataObjects
{
    public class Injury
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public DateTime ScratchDate { get; set; }
    }
}
