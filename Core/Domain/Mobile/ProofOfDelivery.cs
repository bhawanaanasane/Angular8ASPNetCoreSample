using FLA.Core.Domain.BaseTable;
using FLA.Core.Domain.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Mobile
{
    public class ProofOfDelivery:BaseEntity
    {
        public string ReceiverName { get; set; }
        public byte[] SignatureImg { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public long DispatchId { get; set; }
        public virtual Dispatch Dispatch { get; set; }
        public long PickupDeliveryContactsId { get; set; }
        public virtual PickupDeliveryContacts PickupDeliveryContacts { get; set; }
        public long ClientId { get; set; }
        public long DriverId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
