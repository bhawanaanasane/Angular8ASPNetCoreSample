using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Model.Users
{
    public class PermissionModel
    {
        public long Id { get; set; }
        public long FormNameId { get; set; }
        public bool Read { get; set; }
        public bool Modify { get; set; }
        public bool Delete { get; set; }
        public long ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
