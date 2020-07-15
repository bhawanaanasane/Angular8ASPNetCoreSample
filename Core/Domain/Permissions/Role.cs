using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLA.Core.Domain.Permissions
{
    public partial class Role:BaseEntity
    {
        private ICollection<PermissionRoleMapping> _PermissionRoleMapping;
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public virtual ICollection<PermissionRoleMapping> PermissionRoleMapping
        {
            get { return _PermissionRoleMapping ?? (_PermissionRoleMapping = new List<PermissionRoleMapping>()); }
            protected set { _PermissionRoleMapping = value; }
        }
    }
}
