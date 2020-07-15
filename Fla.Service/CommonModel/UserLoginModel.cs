using FLA.Core.Domain.Permissions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.CommonModel
{
    public class UserLoginModel
    {
        public UserLoginModel()
        {
            AvailableRoles = new List<SelectListItem>();
        }

        private ICollection<Role> _Role;
        public long Id { get; set; }
        public long ClientId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string ContactNo { get; set; }
        public long ParentId { get; set; }
        public bool Active { get; set; }
        public bool LoggedIn { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? TimeOutDate { get; set; }
        public string Token { get; set; }
        public long RoleId { get; set; }
        public virtual ICollection<Role> Role
        {
            get { return _Role ?? (_Role = new List<Role>()); }
            protected set { _Role = value; }
        }
        public IList<SelectListItem> AvailableRoles { get; set; }
    }
}
