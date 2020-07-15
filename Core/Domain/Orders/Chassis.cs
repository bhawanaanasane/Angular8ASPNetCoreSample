using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Orders
{
    public class Chassis : BaseEntity
    {
        public long RentalCompanyId { get; set; }
        public virtual RentalCompany RentalCompany { get; set; }
        public string ChassisNumber { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
