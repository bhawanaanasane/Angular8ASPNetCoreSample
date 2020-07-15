using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Orders
{
    public class RentalCompany : BaseEntity
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long State { get; set; }
        public long ZipCode { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
