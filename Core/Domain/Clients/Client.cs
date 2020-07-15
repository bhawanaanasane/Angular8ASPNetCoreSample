using FLA.Core.Domain.Directory;
using FLA.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Clients
{
    public partial class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Address1  { get; set; }
        public string Address2  { get; set; }
        public string City     { get; set; }
        public long? StateProvinceId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public string ZipCode     { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string StartingDriverCodeNumber { get; set; }
        public string StartingOrderNumber { get; set; }
        public byte[] CompanyImage { get; set; }
        public long UserId { get; set; }
        public string ClientCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
