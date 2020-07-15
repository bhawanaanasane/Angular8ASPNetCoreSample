using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Model.Users
{
    public class RoleModel
    {
        public long Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
    }
}
