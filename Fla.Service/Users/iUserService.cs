using System;
using System.Collections.Generic;
using System.Text;
using FLA.Core.Domain.Permissions;
using FLA.Core.Domain.Security;
using FLA.Core.Domain.Users;

namespace Fla.Service.Users
{
    public interface iUserService
    {
        #region TwilioCredential
        TwilioCredential GetTwilioCredential();
        #endregion
        #region PermissinFormName
        void CreateFormName(FormName formname);
        void UpdateFormName(FormName model);
        void DeleteFormName(FormName model);
         IList<FormName> GetAllForm();
        #endregion
        #region Permission
        void InsertPermission(Permission model);
        void UpdatePermission(Permission model);
        void DeletePermission(Permission model);
        void DeletePermissionList(IList<Permission> model);
        IList<Permission> GetAllPermission(long id);
        Permission GetPermission(long id = 0, long formNameId = 0);
        #endregion
        #region PermissionRoleMapping
        void InsertPermissionRoleMapping(PermissionRoleMapping model);
        void UpdatePermissionRoleMapping(PermissionRoleMapping model);
        void DeletePermissionRoleMapping(PermissionRoleMapping model);
        void DeletePermissionRoleMappingList(IList<PermissionRoleMapping> model);
        IList<PermissionRoleMapping> GetAllPermissionRoleMapping(long roleId);
        PermissionRoleMapping GetPermissionRoleMapping(long id = 0, long roleId = 0);
        PermissionRoleMapping GetPermissionRoleMappingById(long roleId);
        #endregion
        #region Role
        void InsertRole(Role model);
        void UpdateRole(Role model);
        void DeleteRole(Role model);
        IList<Role> GetAllRole(long userId, long clientId);
        IList<Role> GetAllRoleByUserId(string RoleName, long UserId);
        Role GetRole(long id, string roleName, long clintId);
        Role GetRoleById(long id);
        #endregion
        #region User
        void InsertUserLogin(UserLogin _model);

        void UpdateUserLogin(UserLogin _model);

        void DeleteUserLogin(UserLogin _model);

        IList<UserLogin> GetAllUserLogin(long Id = 0, long ClientId = 0, long ParentId = 0, long RoleId = 0);

        UserLogin GetUserLogin(long Id = 0, long CLientId = 0, string UserName = null, string Password = null, long ParentId = 0, long RoleId = 0);
        UserLogin GetUserLoginByClientId(long ClientId);
        UserLogin GetUserLoginByGuid(Guid guid);
        UserLogin GetUserLoginByUserNamePassword(string UserName, string Password);
        #endregion
    }
}
