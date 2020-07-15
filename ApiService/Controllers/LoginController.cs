using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiService.Model;
using ApiService.Model.Users;
using Fla.Service.Clients;
using Fla.Service.Drivers;
using Fla.Service.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region fields


     
        private readonly iDriverService _DriverService;
        private readonly iClientService _ClientService;
        private readonly IUserServiceAPI _UserService;
        private readonly iUserService _UserRepository;
        #endregion

        #region CTOR
        public LoginController(
            iDriverService DriverService,
            iClientService ClientService,
            IUserServiceAPI UserService,
            iUserService UserRepository
          )
        {
            this._DriverService = DriverService;
            this._ClientService = ClientService;
            this._UserRepository = UserRepository;
            this._UserService = UserService;
        }

        #endregion
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserModel userParam)
        {
            ResponseModel _Respose = new ResponseModel();
            var user = _UserService.Authenticate(userParam.UserName, userParam.Password, userParam.ClientCode);

            if (user == null)
            {


                _Respose.Message = "User is not available..";
                _Respose.Status = 0;
                _Respose.Response = user;
                return Ok(_Respose);
            }
            else
            {
                var userDetails = new UserModel
                {
                    Id = user.Id,
                    DriverId = user.DriverId,
                    ClientId = user.ClientId,
                    ClientName = _ClientService.GetClientById(Id: user.ClientId).Name,
                    CreateDate = user.CreateDate,
                    UpdateDate = user.UpdateDate,
                    DriverName = _DriverService.GetDriver(ClientId: user.ClientId, Id: user.DriverId).FirstName + " " + _DriverService.GetDriver(ClientId: user.ClientId, Id: user.DriverId).LastName,
                    UserName = user.UserName,
                    Password = user.Password,
                    ClientCode = user.ClientCode
                };
                _Respose.Message = "Success";
                _Respose.Status = 1;
                _Respose.Response = userDetails;
                return Ok(_Respose);
            }

        }


        [AllowAnonymous]
        [HttpPost("authenticateWeb")]
        public IActionResult AuthenticateWeb([FromBody]UserLoginModel loginModel)
        {
            ResponseModel _Respose = new ResponseModel();
            var Credentail = _UserRepository.GetTwilioCredential();
            string EncryptPassword = Encrypt(Credentail.ShaKey, loginModel.Password);
            loginModel.Password = EncryptPassword;
            var user = _UserService.AuthenticateWeb(loginModel.UserName, loginModel.Password);

            if (user == null)
            {


                _Respose.Message = "User is not available..";
                _Respose.Status = 0;
                _Respose.Response = null;
                return Ok(user);
            }
            else
            {
                var userDetails = new UserLoginModel
                {
                    Id = user.Id,
                    ClientId = user.ClientId,
                    FirstName = user.FirstName,
                   ParentId=user.ParentId,
                    Active = user.Active,
                    CreateDate = user.CreateDate,
                    LastUpdateDate = user.LastUpdateDate,
                    RoleId = user.RoleId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Token = user.Token,
                };
                _Respose.Message = "Success";
                _Respose.Status = 1;
                _Respose.Response = userDetails;
                return Ok(user);
            }

        }
        [NonAction]
        public string Encrypt(string key, string data)
        {
            string encData = null;
            byte[][] keys = GetHashKeys(key);

            try
            {
                encData = EncryptStringToBytes_Aes(data, keys[0], keys[1]);
            }
            catch (CryptographicException) { }
            catch (ArgumentNullException) { }

            return encData;
        }
        [NonAction]
        private static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =
                            new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }
        [NonAction]
        private byte[][] GetHashKeys(string key)
        {
            byte[][] result = new byte[2][];
            Encoding enc = Encoding.UTF8;

            SHA256 sha2 = new SHA256CryptoServiceProvider();

            byte[] rawKey = enc.GetBytes(key);
            byte[] rawIV = enc.GetBytes(key);

            byte[] hashKey = sha2.ComputeHash(rawKey);
            byte[] hashIV = sha2.ComputeHash(rawIV);

            Array.Resize(ref hashIV, 16);

            result[0] = hashKey;
            result[1] = hashIV;

            return result;
        }
    }
}