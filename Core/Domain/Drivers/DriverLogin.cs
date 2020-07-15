using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Drivers
{
    public class DriverLogin:BaseEntity
    {
        public long DriverId { get; set; }
        public long ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
