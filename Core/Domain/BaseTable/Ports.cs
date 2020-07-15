using FLA.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.BaseTable
{
   public partial class Ports:BaseEntity
    {
        public string PortName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long? StateProvinceId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public string PortZipCode { get; set; }
        public string ContactNo { get; set; }
        public long ClientId { get; set; }
        public bool Active { get; set; }
        public bool CheckPort { get; set; }
        public long UserLoginId { get; set; }
        public string WebsiteURL { get; set; }
        public bool PortLoginFlag { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
