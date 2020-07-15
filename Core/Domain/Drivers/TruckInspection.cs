using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Drivers
{
    public class TruckInspection : BaseEntity
    {
        public  long DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public DateTime InspectionDate  { get; set; }
        public bool PassFlag { get; set; }
        public bool FailFlag { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal InvoiceAmt { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
