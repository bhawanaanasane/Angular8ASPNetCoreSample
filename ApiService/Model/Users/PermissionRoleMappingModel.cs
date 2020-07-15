using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Model.Users
{
    public class PermissionRoleMappingModel
    {
        public long Id { get; set; }
        public long PermissionId { get; set; }
        public long RoleId { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
