using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.BaseTable
{
   public partial class PickupDeliveryContacts:BaseEntity
    {
        public virtual PickupDelivery PickupDelivery { get; set; }
        public long ClientId { get; set; }
        public long PickupDeliveryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailNotification { get; set; }
        public bool SMSNotification { get; set; }
        public bool ActiveFlag { get; set; }
        public long UserLoginId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
