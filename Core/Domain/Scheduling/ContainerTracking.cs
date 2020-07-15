using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Scheduling
{
   public class ContainerTracking:BaseEntity
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public long DriverId { get; set; }
        public long ClientId { get; set; }
        public long DispatchId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
