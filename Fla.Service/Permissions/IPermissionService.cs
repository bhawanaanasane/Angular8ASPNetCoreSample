using FLA.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Permissions
{
   public interface IPermissionService
    {
        bool Authorize(int RoleId);

        /// <summary>
        /// Authorize permission
        
        bool Authorize(int RoleId, UserLogin user);
    }
}
