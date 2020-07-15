using FLA.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.BaseTable
{
   public partial class PickupDelivery:BaseEntity
    {
        public long ClientId { get; set; }
        public long UserId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long? StateProvinceId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public long? PortsId { get; set; }
        public bool Port { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
