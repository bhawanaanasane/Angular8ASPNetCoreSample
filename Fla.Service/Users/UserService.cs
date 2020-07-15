using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FLA.Core.Domain.Permissions;
using FLA.Core.Domain.Security;
using FLA.Core.Domain.Users;
using FLA.Data.Interfaces;

namespace Fla.Service.Users
{
    public class UserService:iUserService
    {
        private readonly IRepository<FormName> _formNameRepository;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<PermissionRoleMapping> _permissionRoleMappingRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserLogin> _userLoginMappingRepository;
        private readonly IRepository<TwilioCredential> _twilioCredential;
        private readonly IRepository<UserLogin> _UserLoginMappingRepository;
        public UserService(IRepository<FormName> formNameRepository, IRepository<Permission> permissionRepository, IRepository<PermissionRoleMapping> permissionRoleMappingRepository, IRepository<Role> roleRepository, IRepository<UserLogin> userLoginMappingRepository, IRepository<TwilioCredential> twilioCredential, IRepository<UserLogin> UserLoginMappingRepository)
        {
            this._formNameRepository = formNameRepository;
            this._permissionRepository = permissionRepository;
            this._permissionRoleMappingRepository = permissionRoleMappingRepository;
            this._roleRepository = roleRepository;
            this._userLoginMappingRepository = userLoginMappingRepository;
            this._twilioCredential = twilioCredential;
            this._UserLoginMappingRepository = UserLoginMappingRepository;
        }
        #region TwilioCredential
        public TwilioCredential GetTwilioCredential()
        {
            var quary = _twilioCredential.Table;
            return quary.FirstOrDefault();
        }
        #endregion
        #region PermissionFormName
        public void CreateFormName(FormName formname)
        {
            if (formname == null)
                throw new ArgumentNullException(nameof(FormName));
            _formNameRepository.Insert(formname);
        }

        public void UpdateFormName(FormName model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _formNameRepository.Update(model);
        }
        public void DeleteFormName(FormName model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _formNameRepository.Delete(model);
        }
        public IList<FormName> GetAllForm()
        {
            var quary = _formNameRepository.Table;
            return quary.ToList();
        }

        public FormName GetFormName(long id = 0, string tittle = null)
        {
            var quary = _formNameRepository.Table;
            if (id != 0)
            {
                quary = quary.Where(a => a.Id == id);
            }
            if (tittle != null)
            {
                quary = quary.Where(a => a.Tittle == tittle);
            }
            return quary.FirstOrDefault();
        }
        #endregion

        #region Permission
        public void InsertPermission(Permission model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRepository.Insert(model);
        }

        public void UpdatePermission(Permission model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRepository.Update(model);
        }
        public void DeletePermission(Permission model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRepository.Delete(model);
        }
        public void DeletePermissionList(IList<Permission> model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRepository.Delete(model);
        }
        public IList<Permission> GetAllPermission(long id)
        {
            var quary = _permissionRepository.Table;
            if (id != 0)
            {
                quary = quary.Where(a => a.Id == id);
            }
            return quary.ToList();
        }

        public Permission GetPermission(long id = 0, long formNameId = 0)
        {
            var quary = _permissionRepository.Table;
            if (id != 0)
            {
                quary = quary.Where(a => a.Id == id);
            }
            if (formNameId != 0)
            {
                quary = quary.Where(a => a.FormNameId == formNameId);
            }
            return quary.FirstOrDefault();
        }
        #endregion

        #region PermissionRoleMapping
        public void InsertPermissionRoleMapping(PermissionRoleMapping model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRoleMappingRepository.Insert(model);
        }
        public void UpdatePermissionRoleMapping(PermissionRoleMapping model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRoleMappingRepository.Update(model);
        }
        public void DeletePermissionRoleMapping(PermissionRoleMapping model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRoleMappingRepository.Delete(model);
        }
        public void DeletePermissionRoleMappingList(IList<PermissionRoleMapping> model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _permissionRoleMappingRepository.Delete(model);
        }

        public IList<PermissionRoleMapping> GetAllPermissionRoleMapping(long roleId)
        {
            var quary = _permissionRoleMappingRepository.Table;
            if (roleId != 0)
            {
                quary = quary.Where(a => a.RoleId == roleId);
            }

            return quary.ToList();
        }
        public PermissionRoleMapping GetPermissionRoleMapping(long id = 0, long roleId = 0)
        {
            var quary = _permissionRoleMappingRepository.Table;
            if (id != 0)
            {
                quary = quary.Where(a => a.Id == id);
            }
            if (roleId != 0)
            {
                quary = quary.Where(a => a.RoleId == roleId);
            }
            return quary.FirstOrDefault();
        }

        public PermissionRoleMapping GetPermissionRoleMappingById(long roleId)
        {
            var quary = _permissionRoleMappingRepository.Table.Where(a => a.Id == roleId);
            return quary.FirstOrDefault();
        }
        #endregion

        #region Role
        public void InsertRole(Role model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _roleRepository.Insert(model);
        }

        public void UpdateRole(Role model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _roleRepository.Update(model);
        }

        public void DeleteRole(Role model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(FormName));
            _roleRepository.Delete(model);
        }
        public IList<Role> GetAllRole(long userId, long clientId)
        {
            var quary = _roleRepository.Table;
            if (userId != 0)
            {
                quary = quary.Where(a => a.UserId == userId);
            }
            if (clientId != 0)
            {
                quary = quary.Where(a => a.ClientId == clientId);
            }
            return quary.ToList();
        }

        public IList<Role> GetAllRoleByUserId(string RoleName, long UserId)
        {
            var quary = _roleRepository.Table.Where(a => a.RoleName == RoleName && a.UserId == UserId);
            return quary.ToList();
        }

        public Role GetRole(long id, string roleName, long clintId)
        {
            var quary = _roleRepository.Table;
            if (id != 0)
            {
                quary = quary.Where(a => a.Id == id);
            }
            if (clintId != 0)
            {
                quary = quary.Where(a => a.ClientId == clintId);
            }
            if (roleName != null)
            {
                quary = quary.Where(a => a.RoleName == roleName);
            }
            return quary.FirstOrDefault();
        }
        public Role GetRoleById(long id)
        {
            var quary = _roleRepository.Table.Where(a => a.Id == id);

            return quary.FirstOrDefault();
        }
        #endregion

        #region User
        public void InsertUserLogin(UserLogin _model)
        {
            if (_model == null)
                throw new ArgumentNullException(nameof(FormName));
            _UserLoginMappingRepository.Insert(_model);
        }
        public void UpdateUserLogin(UserLogin _model)
        {
            if (_model == null)
                throw new ArgumentNullException(nameof(FormName));
            _UserLoginMappingRepository.Update(_model);
        }
        public void DeleteUserLogin(UserLogin _model)
        {
            if (_model == null)
                throw new ArgumentNullException(nameof(FormName));
            _UserLoginMappingRepository.Delete(_model);
        }
        public IList<UserLogin> GetAllUserLogin(long Id, long ClientId, long ParentId, long RoleId)
        {
            var quary = _UserLoginMappingRepository.Table;
            if (Id != 0)
            {
                quary = quary.Where(a => a.Id == Id);
            }
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }
            if (ParentId != 0)
            {
                quary = quary.Where(a => a.ParentId == ParentId);
            }
            if (RoleId != 0)
            {
                quary = quary.Where(a => a.RoleId == RoleId);
            }

            return quary.ToList();
        }
        public UserLogin GetUserLoginByClientId(long ClientId)
        {
            var quary = _UserLoginMappingRepository.Table.Where(a => a.ClientId == ClientId);

            return quary.FirstOrDefault();
        }
        public UserLogin GetUserCheck(string UserName, string Password)
        {
            var quary = _UserLoginMappingRepository.Table.Where(a => a.UserName == UserName && a.Password == Password);
            return quary.FirstOrDefault();
        }

        public UserLogin GetUserLogin(long Id, long ClientId, string UserName, string Password, long ParentId, long RoleId)
        {
            var quary = _UserLoginMappingRepository.Table;
            if (Id != 0)
            {
                quary = quary.Where(a => a.Id == Id);
            }
            if (UserName != null)
            {
                quary = quary.Where(a => a.UserName == UserName);
            }
            if (Password != null)
            {
                quary = quary.Where(a => a.Password == Password);
            }
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }
            if (ParentId != 0)
            {
                quary = quary.Where(a => a.ParentId == ParentId);
            }
            if (RoleId != 0)
            {
                quary = quary.Where(a => a.RoleId == RoleId);
            }
            return quary.FirstOrDefault();
        }
        public UserLogin GetUserLoginByGuid(Guid Guid)
        {

            if (Guid != Guid.Empty)
            {
                var quary = _UserLoginMappingRepository.Table;
                quary = quary.Where(a => a.UserLoginGuid == Guid);
                return quary.FirstOrDefault();
            }
            else
            {
                return null;
            }



        }

        public UserLogin GetUserLoginByUserNamePassword(string UserName,string Password)
        {

            if (UserName != "" && Password!="")
            {
                var quary = _UserLoginMappingRepository.Table.Where(a=>a.UserName== UserName && a.Password==Password);
              
                return quary.FirstOrDefault();
            }
            else
            {
                return null;
            }



        }
        #endregion
    }
}
