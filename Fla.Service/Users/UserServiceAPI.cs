using Fla.Service.Drivers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Fla.Service.Helper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Fla.Service.CommonModel;
using Fla.Service.Permissions;

namespace Fla.Service.Users
{
    public interface IUserServiceAPI
    {
        UserModel Authenticate(string username, string password, string ClientCode);

        UserLoginModel AuthenticateWeb(string username, string password);
        // IEnumerable<User> GetAll();
    }

    public class UserServiceAPI : IUserServiceAPI
    {


        private readonly AppSettings _appSettings;
        private readonly iDriverService _DriverService;
        private readonly IPermissionService _permissionService;
        private readonly iUserService _UserService;

        public UserServiceAPI(IOptions<AppSettings> appSettings, iDriverService DriverService, IPermissionService permissionService, iUserService UserService)
        {

            _appSettings = appSettings.Value;
            this._DriverService = DriverService;
            this._permissionService = permissionService;
            this._UserService = UserService;
        }

        public UserModel Authenticate(string username, string password, string ClientCode)
        {
            var user = _DriverService.VerifyDriverByUsernamePassword(username, password, ClientCode);
            if (user == null)
            {
              
                return null;
            }
            if (user == null)
            {
                
                return null;
            }


            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserModel userModel = new UserModel();
            userModel.Id = user.Id;
            userModel.Token = tokenHandler.WriteToken(token);
            userModel.UserName = user.UserName;
            userModel.Password = password;
            userModel.DriverName = _DriverService.GetDriver(ClientId: user.ClientId, Id: user.DriverId).FirstName + " " + _DriverService.GetDriver(ClientId: user.ClientId, Id: user.DriverId).LastName;
            userModel.CreateDate = user.CreateDate;
            userModel.UpdateDate = user.UpdateDate;
            userModel.DriverId = user.DriverId;
            userModel.ClientId = user.ClientId;
            userModel.ClientCode = user.ClientCode;
            // remove password before returning

            return userModel;
        }

        public UserLoginModel AuthenticateWeb(string username, string password)
        {
            var user = _UserService.GetUserLoginByUserNamePassword(username, password);
            if (user == null)
            {

                return null;
            }
            if (user == null)
            {

                return null;
            }


            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserLoginModel userModel = new UserLoginModel();
            userModel.Id = user.Id;
            userModel.Token = tokenHandler.WriteToken(token);
            userModel.UserName = user.UserName;
            userModel.Password = password;
            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.CreateDate = user.CreateDate;
            userModel.LastUpdateDate = user.LastUpdateDate;
            userModel.ParentId = user.ParentId;
            userModel.ClientId = user.ClientId;
            userModel.Active = user.Active;
            userModel.RoleId = user.RoleId;
            // remove password before returning

            return userModel;
        }
    }
}
