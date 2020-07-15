using Fla.Service.Helper;
using Fla.Service.Users;
using FLA.Core.Domain.Permissions;
using FLA.Core.Domain.Users;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Permissions
{
    public class PermissionService:IPermissionService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer role ID
        /// {1} : permission system name
        /// </remarks>
        private const string PERMISSIONS_ALLOWED_KEY = "Nop.permission.allowed-{0}-{1}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string PERMISSIONS_PATTERN_KEY = "Nop.permission.";

        #endregion

        #region Fields

        private readonly IRepository<Permission> _permissionRecordRepository;
        private readonly IRepository<PermissionRoleMapping> _permissionRecord_Role_Mapping;
        private readonly iUserService _userService;
        private readonly IWorkContext _workContext;


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="permissionRecordRepository">Permission repository</param>
        /// <param name="customerService">Customer service</param>
        /// <param name="workContext">Work context</param>
        /// <param name="localizationService">Localization service</param>
        /// <param name="languageService">Language service</param>
        /// <param name="cacheManager">Static cache manager</param>
        public PermissionService(IRepository<Permission> permissionRecordRepository,
            iUserService userService,
            IWorkContext workContext)
        {
            this._permissionRecordRepository = permissionRecordRepository;
            this._userService = userService;
            this._workContext = workContext;


        }

        #endregion

        #region Utilities

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customerRole">Customer role</param>
        /// <returns>true - authorized; otherwise, false</returns>
        protected virtual bool Authorize(int FormId, Role Role)
        {
            if (FormId == 0)
                return false;


            foreach (var permission1 in _userService.GetAllPermissionRoleMapping(roleId: Role.Id))

                if (permission1.Permission.FormNameId == FormId)
                    return true;


            return false;

        }

        #endregion

        #region Methods

        ///// <summary>
        ///// Delete a permission
        ///// </summary>
        ///// <param name="permission">Permission</param>
        //public virtual void DeletePermissionRecord(PermissionRecord permission)
        //{
        //    if (permission == null)
        //        throw new ArgumentNullException(nameof(permission));

        //    _permissionRecordRepository.Delete(permission);

        //}

        ///// <summary>
        ///// Gets a permission
        ///// </summary>
        ///// <param name="permissionId">Permission identifier</param>
        ///// <returns>Permission</returns>
        //public virtual PermissionRecord GetPermissionRecordById(int permissionId)
        //{
        //    if (permissionId == 0)
        //        return null;

        //    return _permissionRecordRepository.GetById(permissionId);
        //}

        ///// <summary>
        ///// Gets a permission
        ///// </summary>
        ///// <param name="systemName">Permission system name</param>
        ///// <returns>Permission</returns>
        //public virtual PermissionRecord GetPermissionRecordBySystemName(string systemName)
        //{
        //    if (string.IsNullOrWhiteSpace(systemName))
        //        return null;

        //    var query = from pr in _permissionRecordRepository.Table
        //                where pr.SystemName == systemName
        //                orderby pr.Id
        //                select pr;

        //    var permissionRecord = query.FirstOrDefault();
        //    return permissionRecord;
        //}

        ///// <summary>
        ///// Gets all permissions
        ///// </summary>
        ///// <returns>Permissions</returns>
        //public virtual IList<PermissionRecord> GetAllPermissionRecords()
        //{
        //    var query = from pr in _permissionRecordRepository.Table
        //                orderby pr.Name
        //                select pr;
        //    var permissions = query.ToList();
        //    return permissions;
        //}

        ///// <summary>
        ///// Inserts a permission
        ///// </summary>
        ///// <param name="permission">Permission</param>
        //public virtual void InsertPermissionRecord(PermissionRecord permission)
        //{
        //    if (permission == null)
        //        throw new ArgumentNullException(nameof(permission));

        //    _permissionRecordRepository.Insert(permission);

        //}

        ///// <summary>
        ///// Updates the permission
        ///// </summary>
        ///// <param name="permission">Permission</param>
        //public virtual void UpdatePermissionRecord(Permission permission)
        //{
        //    if (permission == null)
        //        throw new ArgumentNullException(nameof(permission));

        //    _permissionRecordRepository.Update(permission);

        //}

        ///// <summary>
        ///// Install permissions
        ///// </summary>
        ///// <param name="permissionProvider">Permission provider</param>
        //public virtual void InstallPermissions(IPermissionProvider permissionProvider)
        //{
        //    //install new permissions
        //    var permissions = permissionProvider.GetPermissions();
        //    //default customer role mappings
        //    var defaultPermissions = permissionProvider.GetDefaultPermissions().ToList();

        //    foreach (var permission in permissions)
        //    {
        //        var permission1 = GetPermissionRecordBySystemName(permission.SystemName);
        //        if (permission1 != null)
        //            continue;

        //        //new permission (install it)
        //        permission1 = new Permission
        //        {
        //            Name = permission.Name,
        //            SystemName = permission.SystemName,
        //            Category = permission.Category,
        //        };


        //        //save new permission
        //        InsertPermissionRecord(permission1);


        //    }
        //}

        //public virtual void InsertPermissionRecordRoleMapping(PermissionRoleMapping permissionRoleMappingProvider)
        //{
        //    if (permissionRoleMappingProvider == null)
        //        throw new ArgumentNullException(nameof(permissionRoleMappingProvider));

        //    _permissionRecord_Role_Mapping.Insert(permissionRoleMappingProvider);
        //}

        ///// <summary>
        ///// Uninstall permissions
        ///// </summary>
        ///// <param name="permissionProvider">Permission provider</param>
        //public virtual void UninstallPermissions(IPermissionProvider permissionProvider)
        //{
        //    var permissions = permissionProvider.GetPermissions();
        //    foreach (var permission in permissions)
        //    {
        //        var permission1 = GetPermissionRecordBySystemName(permission.SystemName);
        //        if (permission1 != null)
        //        {
        //            DeletePermissionRecord(permission1);

        //        }
        //    }
        //}

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        //public virtual bool Authorize(int FormId)
        //{
        //    return Authorize(FormId, _workContext.CurrentUser);
        //}



        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        //public virtual bool Authorize(int FormNameId, UserLogin user)
        //{
        //    if (FormNameId == 0)
        //        return false;

        //    if (user == null)
        //        return false;

        //    //old implementation of Authorize method
        //    //var customerRoles = customer.CustomerRoles.Where(cr => cr.Active);
        //    //foreach (var role in customerRoles)
        //    //    foreach (var permission1 in role.PermissionRecords)
        //    //        if (permission1.SystemName.Equals(permission.SystemName, StringComparison.InvariantCultureIgnoreCase))
        //    //            return true;

        //    //return false;

        //    return Authorize(FormNameId, user);
        //}

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(int FormNameId)
        {
            return Authorize(FormNameId, _workContext.CurrentUser);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(int FormNameId, UserLogin user)
        {
            if (FormNameId == 0)
                return false;
            if (user == null)
                return false;
            var Roles = user.Role;
            // foreach (var role in customerRoles)
            if (Authorize(FormNameId, Roles))
                //yes, we have such permission
                return true;

            //no permission found
            return false;
        }
        #endregion
    }
}
