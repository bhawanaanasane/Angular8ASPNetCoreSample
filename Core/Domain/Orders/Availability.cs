using FLA.Core.EnumStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Orders
{
    public class Availability : BaseEntity
    {
        public long ContainersId { get; set; }
        public virtual Containers Containers { get; set; }
        public bool Available { get; set; }
        public DateTime? LastFreeDay { get; set; }
        public DateTime? FirstDayAvailable { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ETA { get; set; }
        public DateTime? LastChecked { get; set; }
        public string Location { get; set; }
        public bool TMF { get; set; }
        public bool FreightSSLHold { get; set; }
        public bool CustomsHold { get; set; }
        public bool USDAHold { get; set; }
        public bool FDAHold { get; set; }
        public bool HazmatHold { get; set; }
        public bool TerminalHold { get; set; }
        public bool StorageChargesHold { get; set; }
        public bool ExtraHold { get; set; }
        public bool XrayHold { get; set; }
        public bool FeeDueHold { get; set; }
        public decimal? TotalFees { get; set; }
        public long ClientId { get; set; }
        public long StatusId { get; set; }
        public Status Status
        {
            get { return (Status)StatusId; }
            set { StatusId = (long)value; }
        }
        public DateTime? CutOffDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }



    }
   
}
