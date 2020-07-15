using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fla.Service.Common;
using Fla.Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FLA.Core.Domain.Permissions;
using ApiService.Model;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonServiceController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly iUserService _userService;
        public CommonServiceController(ICommonService commonService, iUserService userService)
        {
            this._commonService = commonService;
            this._userService = userService;
        }
        [HttpGet("GetAllState")]
        public IActionResult GetAllState()
        {
            ResponseModel _Response = new ResponseModel();
            try
            {
                var State = _commonService.GetState(CountryId: 1);
                _Response.Message = "Success";
                _Response.Status = 1;
                _Response.Response = State;
            }
            catch(Exception ex)
            {
                _Response.Message = "Fail: "+ ex.ToString();
                _Response.Status = 0;
                _Response.Response = null;
            }
            return Ok(_Response);
        }

        [HttpGet("GetRoleById/{ClientId},{UserId}")]
        public IActionResult GetRoleById(long ClientId, long UserId)
        {
            var Role = _commonService.GetRoleById( ClientId,  UserId);
            return Ok(Role);
        }

       [HttpGet("CreateRole/{RoleName},{ClientId},{UserId}")]
        public IActionResult CreateRole(string RoleName,long ClientId,long UserId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var RoleList = _userService.GetAllRoleByUserId(RoleName: RoleName, UserId: UserId);
                if (RoleList.Count == 0)
                {

                    var Model = new Role();
                    Model.UserId = UserId;
                    Model.ClientId = ClientId;
                    Model.CreateDate = DateTime.UtcNow;
                    Model.LastUpdateDate = DateTime.UtcNow;
                    Model.RoleName = RoleName;
                    _userService.InsertRole(Model);
                    var RoleCount = _userService.GetAllPermissionRoleMapping(roleId: Model.Id).ToList();
                    if (RoleCount.Count < 1)
                    {
                        var Forms = _userService.GetAllForm().ToList();
                        if (Forms.Count > 0)
                        {
                            foreach (var Item in Forms)
                            {
                                var PermissionDetail = new Permission();
                                PermissionDetail.FormNameId = Item.Id;
                                PermissionDetail.ClientId = ClientId;
                                PermissionDetail.Read = false;
                                PermissionDetail.Modify = false;
                                PermissionDetail.Delete = false;

                                _userService.InsertPermission(PermissionDetail);
                                var RoleMapDetail = new PermissionRoleMapping();
                                RoleMapDetail.RoleId = Model.Id;
                                RoleMapDetail.ClientId = ClientId;
                                RoleMapDetail.PermissionId = PermissionDetail.Id;
                                _userService.InsertPermissionRoleMapping(RoleMapDetail);
                            }
                        }
                    }
                    response.Message = "Success";
                    response.Status = 1;
                    response.Response = null;

                }
                else
                {
                    response.Message = "Role Already exist";
                    response.Status = 0;
                    response.Response = null;
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.ToString();
                response.Status = 0;
                response.Response = null;
            }
            return Ok(response);
        }
    }
}