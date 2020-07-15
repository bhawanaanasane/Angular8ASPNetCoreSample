using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Scheduling
{
    public class SegmentType:BaseEntity
    {
        public string Description { get; set; }
        public bool TerminationFlag { get; set; }
        public long OrderSequence { get; set; }
    }
}
