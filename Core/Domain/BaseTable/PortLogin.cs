using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.BaseTable
{
    public partial class PortLogin : BaseEntity
    {
       
        public long PortsId { get; set; }
        public long ClientId { get; set; }
        public virtual Ports Ports { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
