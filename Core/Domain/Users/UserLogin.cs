using System;
using System.Collections.Generic;
using System.Text;
using FLA.Core.Domain.Permissions;

namespace FLA.Core.Domain.Users
{
    public partial class UserLogin : BaseEntity
    {
        public UserLogin()
        {
            this.UserLoginGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the customer GUID
        /// </summary>
        public Guid UserLoginGuid { get; set; }
        //private ICollection<Role> _role;
        public long ClientId { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public long ParentId { get; set; }
        public bool Active { get; set; }
        public bool LoggedIn { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? TimeOutDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string LastIpAddress { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the customer account is system
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// Gets or sets the customer system name
        /// </summary>
        public string SystemName { get; set; }

        //public virtual ICollection<Role> Roles
        //{
        //    get { return _role ?? (_role = new List<Role>()); }
        //    protected set { _role = value; }
        //}
    }
}
