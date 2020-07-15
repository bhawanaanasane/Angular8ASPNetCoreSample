using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;
using Fla.Service.Users;
using FLA.Core.Domain.Permissions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly iUserService IUserServiceRepository;
        private readonly IAuthenticationService _authenticationService;
        public UserController(iUserService iUserServiceRepository)
        {
            this.IUserServiceRepository = iUserServiceRepository;
        }

        public IActionResult authenticate(string UserName,string Password)
        {

            return Ok();
        }
        [HttpGet("CreateForm/{formName},{clientId}")]
        public IActionResult CreateForm(string formName,long clientId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                FormName form = new FormName()
                {
                    Tittle = formName,
                    CreateDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                };
                //   IUserServiceRepository.CreateFormName(_form);
                response.Message = "Success";
                response.Status = 1;
                response.Response = null;
            }
            catch (Exception ex)
            {
                response.Message = "Fail:"+ ex.ToString();
                response.Status = 0;
                response.Response = null;
            }
            return Ok(response);
        }
    }
}