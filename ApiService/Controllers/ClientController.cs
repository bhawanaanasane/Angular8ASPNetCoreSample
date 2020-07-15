using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiService.AngularModels.A_ClientModel;
using ApiService.Model;
using ApiService.Model.Users;
using ApiService.Utils;
using Fla.Service.Clients;
using Fla.Service.Common;
using Fla.Service.Model.Clients;
using Fla.Service.Users;
using FLA.Core.Domain.Clients;
using FLA.Core.Domain.Permissions;
using FLA.Core.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly iClientService _ClientServiceRepository;
        private readonly iUserService _UserServiceRepository;
        private readonly ICommonService _CommonServiceRepository;
        public ClientController(iClientService ClientServiceRepository, iUserService UserServiceRepository, ICommonService CommonServiceRepository)
        {
           this. _ClientServiceRepository = ClientServiceRepository;
            this._UserServiceRepository = UserServiceRepository;
            this._CommonServiceRepository = CommonServiceRepository;
        }
        #region CreateClient
        [HttpPost("CreateClient")]
        public IActionResult CreateClient( A_ClientModel _clientModel)
        {
            ResponseModel _responseModel = new ResponseModel();
            try
            {

                if (_clientModel!=null)
                {
                    if (_UserServiceRepository.GetUserLogin(UserName: _clientModel.UserName) == null)
                    {
                        if (_clientModel != null && _clientModel.RoleId > 0)
                        {
                            Client ClientData = new Client();
                            
                            ClientData.Name = _clientModel.Name;
                            ClientData.Address1 = _clientModel.Address1;
                            ClientData.Address2 = _clientModel.Address2;
                            ClientData.City = _clientModel.City;
                            ClientData.StateProvinceId= _clientModel.StateProvinceId;
                            ClientData.ZipCode = _clientModel.ZipCode;
                            ClientData.PhoneNumber = _clientModel.PhoneNumber;
                            ClientData.FaxNumber = _clientModel.FaxNumber;
                            ClientData.StartingDriverCodeNumber = _clientModel.StartingDriverCodeNumber;
                            ClientData.StartingOrderNumber = _clientModel.StartingOrderNumber;
                            ClientData.CreateDate = DateTime.UtcNow;
                            ClientData.LastUpdateDate = DateTime.UtcNow;
                            ClientData.CompanyImage = _clientModel.CompanyImage;
                            ClientData.UserId = _clientModel.UserId;
                            ClientData.ClientCode = _clientModel.ClientCode;
                            ClientData.StateProvince = _CommonServiceRepository.GetStateByid(Convert.ToInt64(_clientModel.StateProvinceId));
                            if (ClientData != null)
                            {
                                _ClientServiceRepository.InsertClient(ClientData);
                                UserLogin Login = new UserLogin();
                                if (_clientModel.UserName!="" && _clientModel.Password!="")
                                {
                                    var Credentail = _UserServiceRepository.GetTwilioCredential();
                                    string EncryptPassword = Encrypt(Credentail.ShaKey, _clientModel.Password);
                                    Login.FirstName = ClientData.Name;
                                    Login.UserLoginGuid = Guid.NewGuid();
                                    Login.UserName = _clientModel.UserName;
                                    Login.Password = EncryptPassword;
                                    Login.ClientId = ClientData.Id;
                                    Login.Active = _clientModel.Active;
                                    Login.ParentId = _clientModel.ParentId;
                                    Login.ContactNo = ClientData.PhoneNumber;
                                    Login.CreateDate = DateTime.UtcNow;
                                    Login.LastUpdateDate = DateTime.UtcNow;
                                    Login.RoleId = _clientModel.RoleId;
                                    Login.Role = _CommonServiceRepository.GetRoleByRoleId(_clientModel.RoleId);
                                    _UserServiceRepository.InsertUserLogin(Login);
                                    var Rolemodel = new Role();
                                    Rolemodel.RoleName = "Admin";

                                    Rolemodel.UserId = Login.Id;
                                    Rolemodel.ClientId = ClientData.Id;
                                    Rolemodel.CreateDate = DateTime.UtcNow;
                                    Rolemodel.LastUpdateDate = DateTime.UtcNow;
                                    var Models = Rolemodel;
                                    _UserServiceRepository.InsertRole(Models);

                                    var Forms = _UserServiceRepository.GetAllForm().ToList();
                                    if (Forms.Count > 0)
                                    {
                                        foreach (var Item in Forms)
                                        {
                                            var PermissionDetail = new Permission();
                                            PermissionDetail.FormNameId = Item.Id;
                                            PermissionDetail.Read = true;
                                            PermissionDetail.Modify = true;
                                            PermissionDetail.Delete = true;
                                            PermissionDetail.ClientId = ClientData.Id;
                                            _UserServiceRepository.InsertPermission(PermissionDetail);
                                            var RoleMapDetail = new PermissionRoleMapping();
                                            RoleMapDetail.RoleId = Models.Id;
                                            RoleMapDetail.ClientId = ClientData.Id;
                                            RoleMapDetail.CreateDate = DateTime.UtcNow;
                                            RoleMapDetail.LastUpdateDate = DateTime.UtcNow;
                                            RoleMapDetail.PermissionId = PermissionDetail.Id;
                                            _UserServiceRepository.InsertPermissionRoleMapping(RoleMapDetail);
                                        }
                                    }

                                }
                            }
                            _responseModel.Message = "Success";
                            _responseModel.Status = 1;
                            _responseModel.Response =null;
                        }
                        else
                        {
                            _responseModel.Message = "User Already Exist..";
                            _responseModel.Status = 0;
                            _responseModel.Response = null;
                        }

                    }
                    else
                    {
                        _responseModel.Message = "Fill User Login..";
                        _responseModel.Status = 0;
                        _responseModel.Response = null;
                    }
                }
                else
                {
                    _responseModel.Message = "Fill Detail Properly..";
                    _responseModel.Status = 0;
                    _responseModel.Response = null;
                }
               
            }
            catch (Exception ex)
            {
                _responseModel.Message = "Fail:"+ex.ToString();
                _responseModel.Status = 0;
                _responseModel.Response = null;
            }
            return Ok(_responseModel);
        }
        #endregion
        #region EditClient
        [HttpGet("GetEditClientData/{ClientId}")]
        public IActionResult GetEditClientData(long ClientId)
        {
            ResponseModel _response = new ResponseModel();
            try
            {
              
                var ClientData = _ClientServiceRepository.GetClientById(Id: ClientId);
                if (ClientData != null)
                {
                    A_ClientModel Model = new A_ClientModel();
                    var Login = _UserServiceRepository.GetUserLoginByClientId(ClientId: ClientId);

                    Model.Id = ClientData.Id;
                    Model.Name = ClientData.Name;
                    Model.Address1 = ClientData.Address1;
                    Model.Address2 = ClientData.Address2;
                    Model.City = ClientData.City;
                    Model.StateProvinceId = ClientData.StateProvinceId;

                    Model.ZipCode = ClientData.ZipCode;
                    Model.PhoneNumber = ClientData.PhoneNumber;
                    Model.FaxNumber = ClientData.FaxNumber;
                    Model.StartingDriverCodeNumber = ClientData.StartingDriverCodeNumber;
                    Model.StartingOrderNumber = ClientData.StartingOrderNumber;
                    Model.CompanyImage = ClientData.CompanyImage;
                    Model.UserId = ClientData.UserId;
                    Model.ClientCode = ClientData.ClientCode;
                    Model.CreateDate = ClientData.CreateDate;
                    Model.LastUpdateDate = ClientData.LastUpdateDate;

                    //login
                    Model.UserLoginId = Login.Id;
                    Model.UserName = Login.UserName;
                    Model.Password = Login.Password;
                    Model.ParentId = Login.ParentId;
                    Model.ClientId = Login.ClientId;
                    Model.Active = Login.Active;
                    Model.LoggedIn = Login.LoggedIn;
                    Model.TimeOutDate = Login.TimeOutDate;
                    Model.Token = null;
                    Model.RoleId = Login.RoleId;

                    _response.Message = "Success";
                    _response.Status = 0;
                    _response.Response = Model;
                }
                else
                {
                    _response.Message = "Data Not Found..";
                    _response.Status = 0;
                    _response.Response = null;
                }
            }catch(Exception ex)
            {
                _response.Message ="Fail:"+ ex.ToString();
                _response.Status = 0;
                _response.Response = null;
            }
            return Ok(_response);
        }
        #endregion
        #region GetClient
        [HttpGet("GetAllClient")]
        public IActionResult GetAllClient()
        {
            ResponseModel _response = new ResponseModel();
            try
            {
                var Client = _ClientServiceRepository.GetAllClient();
                if (Client != null)
                {
                    _response.Message = "Success";
                    _response.Status = 1;
                    _response.Response = Client;
                }
                else
                {
                    _response.Message = "No Record Found..";
                    _response.Status = 0;
                    _response.Response = null;
                }
            }
            catch(Exception ex)
            {
                _response.Message = "Fail:"+ ex.ToString();
                _response.Status = 0;
                _response.Response = null;
            }
            return Ok(_response);
        }
        #endregion

        #region  ClientCode
        [HttpGet("GetMaxClientCode")]
        public IActionResult GetMaxClientCode()
        {
            ResponseModel _responseModel = new ResponseModel();
            try
            {
                string Code = _ClientServiceRepository.GetMaxClientCode();
                _responseModel.Message = "Success";
                _responseModel.Status = 1;
                _responseModel.Response = Code;
            }
            catch (Exception ex)
            {
                _responseModel.Message = "Fail";
                _responseModel.Status = 0;
                _responseModel.Response = null;
            }
            return Ok(_responseModel);
        }
        #endregion
        #region Encryption Decryption
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
        public string Decrypt(string key, string data)
        {
            string decData = null;
            byte[][] keys = GetHashKeys(key);

            try
            {
                decData = DecryptStringFromBytes_Aes(data, keys[0], keys[1]);
            }
            catch (CryptographicException ex) { }
            catch (ArgumentNullException ex) { }

            return decData;
        }

        private static string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Convert.FromBase64String(cipherTextString);

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt =
                            new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public IActionResult VerifyNumber(string MobileNo)
        {
            var Credential = _UserServiceRepository.GetTwilioCredential();
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            string accountSid = Credential.AccountSid;
            string authToken = Credential.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber(Credential.PhoneNumber),
                to: new Twilio.Types.PhoneNumber(MobileNo)
            );
            return Ok( message);
        }
        #endregion
    }



}