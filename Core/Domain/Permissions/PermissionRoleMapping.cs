using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLA.Core.Domain.Permissions
{
    public partial class PermissionRoleMapping:BaseEntity
    {
        public long PermissionId { get; set; }
        public long RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public virtual Permission Permission { get; set; }
        public long ClientId { get; set; }
        public virtual Role Role { get; set; }
    }
}
