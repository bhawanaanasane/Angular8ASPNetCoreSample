using FLA.Core.Domain.Directory;
using FLA.Core.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Common
{
    public interface ICommonService
    {
        #region State
        IList<StateProvince> GetState(long CountryId);
        StateProvince GetStateByid(long stateId);
        #endregion
        #region Role
        IList<Role> GetRoleById(long ClientId, long UserId);
        Role GetRoleByRoleId(long RoleId);
        #endregion
    }
}
