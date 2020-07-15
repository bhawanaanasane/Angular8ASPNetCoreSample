using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Scheduling
{
    public class DriverDispachDetail : BaseEntity
    {
        public long DeliveryId { get; set; }
        public string ContainerNo { get; set; }
        public long TypeId { get; set; }
        public long DispatchId { get; set; }
        public string PU { get; set; }
        public string To { get; set; }
        public string DriverNotes { get; set; }
        public string InvoiceNotes { get; set; }
        public bool Check { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
