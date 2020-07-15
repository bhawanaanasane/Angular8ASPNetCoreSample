using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Orders
{
    public class Size:BaseEntity
    {
        public string Description { get; set; }
        public string FLACode { get; set; }
        public string EIDCode { get; set; }
        public bool DropdownUse { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
