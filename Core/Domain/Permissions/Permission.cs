using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLA.Core.Domain.Permissions
{
    public partial class Permission:BaseEntity
    {
        public long FormNameId { get; set; }
        public bool Read { get; set; }
        public bool Modify { get; set; }
        public bool Delete { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
