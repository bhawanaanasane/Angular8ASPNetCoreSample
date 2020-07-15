using ApiService.Model.Users;
using Fla.Service.Model.Clients;
using FLA.Core.Domain.Clients;
using FLA.Core.Domain.Permissions;
using FLA.Core.Domain.Users;
using FLA.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Utils
{
    public static class MappingExtension
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }
        #region Client

        public static ClientModel ToModelClient(this Client entity)
        {
            return entity.MapTo<Client, ClientModel>();
        }

        public static Client ToEntityClient(this ClientModel model)
        {
            return model.MapTo<ClientModel, Client>();
        }
        #endregion
        #region UserLogin

        public static UserLoginModel ToModelUserLogin(this UserLogin entity)
        {
            return entity.MapTo<UserLogin, UserLoginModel>();
        }

        public static UserLogin ToEntityUserLogin(this UserLoginModel model)
        {
            return model.MapTo<UserLoginModel, UserLogin>();
        }

        public static UserLogin ToEntityUserLogin(this UserLoginModel model, UserLogin destination)
        {
            return model.MapTo(destination);
        }
        public static IList<UserLogin> UserLoginListToEntity(this IList<UserLoginModel> model, IList<UserLogin> destination)
        {
            return model.MapTo(destination);
        }
        public static IList<UserLoginModel> ToModelUserLoginList(this IList<UserLogin> entityList)
        {
            return entityList.MapTo<IList<UserLogin>, IList<UserLoginModel>>();
        }
        public static IList<UserLogin> ToEntityClientPermissions(this IList<UserLoginModel> model)
        {
            return model.MapTo<IList<UserLoginModel>, IList<UserLogin>>();
        }

        #endregion
        #region Role

        public static RoleModel ToModelRole(this Role entity)
        {
            return entity.MapTo<Role, RoleModel>();
        }

        public static Role ToEntityRole(this RoleModel model)
        {
            return model.MapTo<RoleModel, Role>();
        }

        public static Role ToEntityRole(this RoleModel model, Role destination)
        {
            return model.MapTo(destination);
        }
        public static IList<Role> RoleListToEntity(this IList<RoleModel> model, IList<Role> destination)
        {
            return model.MapTo(destination);
        }
        public static IList<RoleModel> ToModelPermissionRoleMappingList(this IList<Role> entityList)
        {
            return entityList.MapTo<IList<Role>, IList<RoleModel>>();
        }
        public static IList<Role> ToEntityRole(this IList<RoleModel> model)
        {
            return model.MapTo<IList<RoleModel>, IList<Role>>();
        }

        #endregion
        #region Permission

        public static PermissionModel ToModelPermission(this Permission entity)
        {
            return entity.MapTo<Permission, PermissionModel>();
        }

        public static Permission ToEntityPermission(this PermissionModel model)
        {
            return model.MapTo<PermissionModel, Permission>();
        }

        public static Permission ToEntityPermission(this PermissionModel model, Permission destination)
        {
            return model.MapTo(destination);
        }
        public static IList<Permission> PermissionListToEntity(this IList<PermissionModel> model, IList<Permission> destination)
        {
            return model.MapTo(destination);
        }
        public static IList<PermissionModel> ToModelPermissionList(this IList<Permission> entityList)
        {
            return entityList.MapTo<IList<Permission>, IList<PermissionModel>>();
        }
        public static IList<Permission> ToEntityPermission(this IList<PermissionModel> model)
        {
            return model.MapTo<IList<PermissionModel>, IList<Permission>>();
        }

        #endregion
        #region PermissionRoleMapping

        public static PermissionRoleMappingModel ToModelPermissionRoleMapping(this PermissionRoleMapping entity)
        {
            return entity.MapTo<PermissionRoleMapping, PermissionRoleMappingModel>();
        }

        public static PermissionRoleMapping ToEntityPermissionRoleMapping(this PermissionRoleMappingModel model)
        {
            return model.MapTo<PermissionRoleMappingModel, PermissionRoleMapping>();
        }

        public static PermissionRoleMapping ToEntityPermissionRoleMapping(this PermissionRoleMappingModel model, PermissionRoleMapping destination)
        {
            return model.MapTo(destination);
        }
        public static IList<PermissionRoleMapping> PermissionRoleMappingListToEntity(this IList<PermissionRoleMappingModel> model, IList<PermissionRoleMapping> destination)
        {
            return model.MapTo(destination);
        }
        public static IList<PermissionRoleMappingModel> ToModelPermissionRoleMappingList(this IList<PermissionRoleMapping> entityList)
        {
            return entityList.MapTo<IList<PermissionRoleMapping>, IList<PermissionRoleMappingModel>>();
        }
        public static IList<PermissionRoleMapping> ToEntityPermissionRoleMapping(this IList<PermissionRoleMappingModel> model)
        {
            return model.MapTo<IList<PermissionRoleMappingModel>, IList<PermissionRoleMapping>>();
        }

        #endregion
    }
}
