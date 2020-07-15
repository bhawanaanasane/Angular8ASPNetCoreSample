using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Drivers
{
    public partial class DrugScreen:BaseEntity
    {
        public long DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public DateTime ScreenDate   { get; set; }
        public long UserId { get; set; }
        public bool PassFlag         { get; set; }
        public bool FailFlag         { get; set; }
        public string InvoiceNumber  { get; set; }
        public decimal InvoiceAmt    { get; set; }
        public long ScreenTypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public long ClientId { get; set; }
        public ScreenType ScreenType
        {
            get
            {
                return (ScreenType)ScreenTypeId;
            }
            set
            {
                ScreenTypeId = (long)value;
            }
        }

    }
    
}
