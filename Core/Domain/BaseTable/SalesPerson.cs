using FLA.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.BaseTable
{
   public class SalesPerson:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public long? StateProvinceId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public bool Active { get; set; }
        public long ClientId { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
