using FLA.Core.EnumStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Scheduling
{
    public class Dispatch : BaseEntity
    {
        public long ContainersId { get; set; }
        public long DriverId { get; set; }
        public DateTime? DateTimeAssigned { get; set; }
        public long SegmentTypeId { get; set; }
        public long PickupDeliveryId { get; set; }
        public long DropLocationId { get; set; }
        public long UserLoginId {get;set;}
        public long ClientId { get; set; }
        public DateTime? ApptDate { get; set; }
        public string ApptTime { get; set; }
        public string ApptNumber { get; set; }
        public DateTime? ActionDate { get; set; }
        public long LoadStatus { get; set; }
        public double? LoadMoney { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public long StatusId { get; set; }
        public Status Status
        {
            get { return (Status)StatusId; }
            set { StatusId = (long)value; }
        }
    }
}
